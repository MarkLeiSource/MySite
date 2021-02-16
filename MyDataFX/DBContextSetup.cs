using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MyDataFX
{
    public class DBContextSetup
    {
        public static void Setup()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            var entityTypes = types.Where(t => t.BaseType == typeof(MyEntity)).ToList();
            AssemblyName dynAssembly = new AssemblyName("DynamicAssembly");
            AssemblyBuilder dynamicAssembly = AppDomain.CurrentDomain.DefineDynamicAssembly(dynAssembly, AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder mb = dynamicAssembly.DefineDynamicModule(dynAssembly.Name, dynAssembly.Name + ".dll");
            TypeBuilder tb = mb.DefineType("MyDynamicContext", TypeAttributes.Public, typeof(DbContext));
            ConstructorBuilder cb1 = tb.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, null);
            ILGenerator ilg = cb1.GetILGenerator();
            ilg.Emit(OpCodes.Ldarg_0);
            ilg.Emit(OpCodes.Ldstr, "SqliteDB");
            ilg.Emit(OpCodes.Call, typeof(DbContext).GetConstructor(new Type[] { typeof(string) }));
            ilg.Emit(OpCodes.Ret);
            ////动态创建属性
            foreach (var entityType in entityTypes)
            {
                FieldBuilder customerNameBldr = tb.DefineField("_" + entityType.Name,
                                                typeof(string),
                                                FieldAttributes.Private);
                PropertyBuilder custNamePropBldr = tb.DefineProperty(entityType.Name,
                                                                 PropertyAttributes.HasDefault,
                                                                 typeof(DbSet<>).MakeGenericType(entityType),
                                                                 null);
                MethodAttributes getSetAttr =
                    MethodAttributes.Public | MethodAttributes.SpecialName |
                        MethodAttributes.HideBySig;
                MethodBuilder custNameGetPropMthdBldr =
                    tb.DefineMethod("get_" + entityType.Name,
                                               getSetAttr,
                                               typeof(DbSet<>).MakeGenericType(entityType),
                                               Type.EmptyTypes);

                ILGenerator custNameGetIL = custNameGetPropMthdBldr.GetILGenerator();

                custNameGetIL.Emit(OpCodes.Ldarg_0);
                custNameGetIL.Emit(OpCodes.Ldfld, customerNameBldr);
                custNameGetIL.Emit(OpCodes.Ret);
                MethodBuilder custNameSetPropMthdBldr =
                    tb.DefineMethod("set_" + entityType.Name,
                                               getSetAttr,
                                               null,
                                               new Type[] { typeof(DbSet<>).MakeGenericType(entityType) });

                ILGenerator custNameSetIL = custNameSetPropMthdBldr.GetILGenerator();

                custNameSetIL.Emit(OpCodes.Ldarg_0);
                custNameSetIL.Emit(OpCodes.Ldarg_1);
                custNameSetIL.Emit(OpCodes.Stfld, customerNameBldr);
                custNameSetIL.Emit(OpCodes.Ret);
                custNamePropBldr.SetGetMethod(custNameGetPropMthdBldr);
                custNamePropBldr.SetSetMethod(custNameSetPropMthdBldr);
            }
            Type classType = tb.CreateType();
            dynamicAssembly.Save(dynAssembly.Name + ".dll");
            Repository.DbContextType = classType;
        }
    }
}

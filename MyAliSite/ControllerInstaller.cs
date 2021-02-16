using Castle.MicroKernel.Registration;
using MyAliSite.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace MyAliSite
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly() //在哪里找寻接口或类
                .BasedOn<IHttpController>() //实现IController接口
                .If(Component.IsInSameNamespaceAs<HomeController>()) //与HomeController在同一个命名空间
                .If(t => t.Name.EndsWith("Controller")) //以"Controller"结尾
                .Configure(c => c.LifestylePerWebRequest()));//每次请求创建一个Controller实例
        }
    }
}
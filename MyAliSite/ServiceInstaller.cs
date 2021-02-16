using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace MyAliSite
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed("MyAliSite")
                                  .Where(type => type.Name.EndsWith("Service"))
                                  .WithService.FromInterface(typeof(IService))
                                  .Configure(c => c.LifestyleTransient()));
        }
    }
}
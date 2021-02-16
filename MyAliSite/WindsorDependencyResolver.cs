using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.Windsor;

namespace MyAliSite
{
    public class WindsorDependencyResolver : System.Web.Http.Dependencies.IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private readonly IWindsorContainer container;

        public WindsorDependencyResolver(IWindsorContainer container)
        {
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
            
        }

        public object GetService(Type serviceType)
        {
            return container.Kernel.HasComponent(serviceType) ? container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.Kernel.HasComponent(serviceType) ? container.ResolveAll(serviceType).Cast<object>() : new object[] { };
        }
    }

    //public class WindsorControllerFactory : System.Web.Http.Dependencies.IDependencyResolver
    //{
    //    private readonly IKernel kernel;
    //    private readonly HttpConfiguration configuration;

    //    public WindsorControllerFactory(IKernel kernel, HttpConfiguration configuration)
    //    {
    //        this.kernel = kernel;
    //        this.configuration = configuration;
    //    }

    //    public IDependencyScope BeginScope()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IHttpController CreateController(HttpControllerContext controllerContext, string controllerName)
    //    {
    //        if (controllerName == null)
    //        {
    //            throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", controllerContext.Request.RequestUri.AbsolutePath));
    //        }

    //        var controller = kernel.Resolve<IHttpController>(controllerName);
    //        controllerContext.Controller = controller;
    //        controllerContext.ControllerDescriptor = new HttpControllerDescriptor(configuration, controllerName, controller.GetType());

    //        return controllerContext.Controller;
    //    }

    //    public void Dispose()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public object GetService(Type serviceType)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<object> GetServices(Type serviceType)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void ReleaseController(IHttpController controller)
    //    {
    //        kernel.ReleaseComponent(controller);
    //    }
    //}
}
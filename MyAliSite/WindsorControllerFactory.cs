using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dependencies;

namespace MyAliSite
{
    public class WindsorControllerFactory : System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IKernel kernel;
        private readonly HttpConfiguration configuration;

        public WindsorControllerFactory(IKernel kernel, HttpConfiguration configuration)
        {
            this.kernel = kernel;
            this.configuration = configuration;
        }

        public IDependencyScope BeginScope()
        {
            throw new NotImplementedException();
        }

        public IHttpController CreateController(HttpControllerContext controllerContext, string controllerName)
        {
            if (controllerName == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", controllerContext.Request.RequestUri.AbsolutePath));
            }

            var controller = kernel.Resolve<IHttpController>(controllerName);
            controllerContext.Controller = controller;
            controllerContext.ControllerDescriptor = new HttpControllerDescriptor(configuration, controllerName, controller.GetType());

            return controllerContext.Controller;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public void ReleaseController(IHttpController controller)
        {
            kernel.ReleaseComponent(controller);
        }
    }
}
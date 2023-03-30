using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Ninject;
using Ninject.Modules;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using UserManagement.Business.Abstract;
using UserManagement.Business.Concrete;
using UserManagement.DataAccess.Abstract;
using UserManagement.DataAccess.Concrete.EntityFramework;
using Ninject.Web.Common;

namespace UserManagement.Business.CrossCuttingConcern.DependencyInjection.Ninject
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel kernel;

        public NinjectControllerFactory()
        {
            kernel = new StandardKernel(new NinjectBindingModule());
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)kernel.Get(controllerType);
        }        
    }
    public class NinjectBindingModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<ICategoryDal>().To<CategoryDal>();
            Kernel.Bind<ICategoryService>().To<CategoryManager>();

            Kernel.Bind<IProductDal>().To<ProductDal>();
            Kernel.Bind<IProductService>().To<ProductManager>();

            Kernel.Bind<IUserDal>().To<UserDal>();
            Kernel.Bind<IUserService>().To<UserManager>();

            Kernel.Bind<IUserRoleDal>().To<UserRoleDal>();
            Kernel.Bind<IUserRoleService>().To<UserRoleManager>();

            Kernel.Bind<IAuthDal>().To<AuthDal>().InRequestScope();
            Kernel.Bind<IAuthService>().To<AuthManager>().InRequestScope();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using VahanBlog.Concrete;
using Ninject;
using System.Linq;
using Moq;
using VahanBlog.Abstract;
using VahanBlog.Entities;
using VahanBlog.Infrastructure.Concrete;
using VahanBlog.Infrastructure;


namespace VahanBlog.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IBlogPostRepository>().To<EFBlogPostRepository>();
            kernel.Bind<IAuthPovider>().To<FormsAuthProvider>();
        }
    }
}

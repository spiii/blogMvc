using blogBl;
using blogBl.Abstract;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blog.Infrastructure
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
            // kernel.Bind<IProductRepository>().To<EFProductRepository>();
            Mock<IPostRepository> mock = new Mock<IPostRepository>();
            List<Post> posts = new List<Post>();
            for (int i = 0; i < 30; i++)
            {
                posts.Add(new Post { title = $"title {i}", idPost = i });
            }

            mock.Setup(m => m.posts).Returns(posts);

            // Bind post repository to mock.
            kernel.Bind<IPostRepository>().ToConstant(mock.Object);
        }
    }
}
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

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }

        private void AddBindings()
        {
            // kernel.Bind<IProductRepository>().To<EFProductRepository>();
            Mock<IPostRepository> mock = new Mock<IPostRepository>();
            mock.Setup(m => m.posts).Returns(new List<Post>
            {
                new Post{title = "title 1"},
                new Post{title = "title 2"},
                new Post{title = "title 3"},
                new Post{title = "title 4"},
                new Post{title = "title 5"},
                new Post{title = "title 6"},
                new Post{title = "title 7"},
                new Post{title = "title 8"},
                new Post{title = "title 9"},
            });

            // Bing post repository to mock.
            kernel.Bind<IPostRepository>().ToConstant(mock.Object);
        }
    }
}
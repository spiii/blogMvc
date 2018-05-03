using blog.helpers;
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

            List<Group> groups = new List<Group>();
            for (int i = 0; i < 3; i++)
            {
                groups.Add(new Group { groupName = $"group {MainHelper.number2String(i+1,true)}", idGroup = i });
            }

            List<Post> posts = new List<Post>();
            for (int i = 0; i < 30; i++)
            {
                posts.Add(new Post { title = $"Post title {i}", idPost = i , groups=groups});
            }

            mock.Setup(m => m.posts).Returns(posts);

            // Bind post repository to mock.
            kernel.Bind<IPostRepository>().ToConstant(mock.Object);
        }
    }
}
using blog.helpers;
using blogBl;
using blogBl.Abstract;
using blogBl.Concrete;
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
            // kernel.Bind<IPostRepository>().To<EFPostRepository>();
            Mock<IPostRepository> mock = new Mock<IPostRepository>();

            List<Group> groups = new List<Group>();
            List<Group> groupsSec = new List<Group>();
            createGroups(groups, 0, 3);
            createGroups(groupsSec, 4, 5);

            List<Post> posts = createPosts(groups, groupsSec);

            mock.Setup(m => m.posts).Returns(posts);

            // Bind post repository to mock.
            kernel.Bind<IPostRepository>().ToConstant(mock.Object);
            kernel.Bind<IVotingProcessor>().To<VotingProcessor>();
        }

        private static List<Post> createPosts(List<Group> groups, List<Group> groupsSec)
        {
            List<Post> posts = new List<Post>();

            for (int i = 0; i < 30; i++)
                posts.Add(new Post { title = $"Post title {i}", idPost = i, groups = i % 2 == 0 ? groups : groupsSec });
            return posts;
        }

        private static void createGroups(List<Group> groups, int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                groups.Add(new Group { groupName = $"group {MainHelper.number2String(i + 1, true)}", idGroup = i });
            }
        }
    }
}
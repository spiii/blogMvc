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
            Mock<IGroupRepository> mockGroups = new Mock<IGroupRepository>();

            List<Group> groups = new List<Group>();
            List<Group> groupsSec = new List<Group>();
            MockCreatorHelper.createGroups(groups, 0, 3);
            MockCreatorHelper.createGroups(groupsSec, 4, 5);

            List<Post> posts = MockCreatorHelper.createPosts(groups, groupsSec);

            mock.Setup(m => m.posts).Returns(posts);
            mockGroups.Setup(m => m.groups).Returns(groups.Concat(groupsSec));

            // Bind post repository to mock.
            kernel.Bind<IPostRepository>().ToConstant(mock.Object);
            kernel.Bind<IGroupRepository>().ToConstant(mockGroups.Object);
            kernel.Bind<IVotingProcessor>().To<VotingProcessor>();
        }


    }
}
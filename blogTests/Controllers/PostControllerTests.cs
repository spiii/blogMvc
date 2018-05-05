using NUnit.Framework;
using blog.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using blogBl.Abstract;
using blogBl;
using blog.Models;
using blogTests;

namespace blog.Controllers.Tests
{
    [TestFixture()]
    public class PostControllerTests
    {
        [Test()]
        public void canSendPaginationViewModel()
        {
            // Arrange
            Mock<IPostRepository> mock = TestHelper.createMockObject();

            // Arrange
            PostController controller = new PostController(mock.Object);
            controller.pageSize = 3;
            // Act
            PostsListViewModel result = (PostsListViewModel)controller.List(null, 2).Model;
            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.currentPage, 2);
            Assert.AreEqual(pageInfo.itemsPerPage, 3);
            Assert.AreEqual(pageInfo.totalPages, 1);
        }

        [Test()]
        public void canFilterPosts()
        {
            // Arrange
            Mock<IPostRepository> mock = TestHelper.createMockObject();
            PostController controller = new PostController(mock.Object);
            controller.pageSize = 3;

            // Action
            Post[] result = ((PostsListViewModel)controller.List("group E", 1).Model)
            .posts.ToArray();
            // Assert
            Assert.AreEqual(result.Length, 2);
            Assert.IsTrue(result[0].title == "P2" && result[0].groups.Select(x => x.groupName).Contains("group E"));
            Assert.IsTrue(result[1].title == "P4" && result[1].groups.Select(x => x.groupName).Contains("group E"));

        }

        [Test()]
        public void canPaginate()
        {
            // Arrange
            Mock<IPostRepository> mock = TestHelper.createMockObject();

            PostController controller = new PostController(mock.Object);
            controller.pageSize = 3;
            // Act
            PostsListViewModel result = (PostsListViewModel)controller.List(null, 2).Model;
            // Assert
            Post[] _posts = result.posts.ToArray();
            Assert.IsTrue(_posts.Length == 2);
            Assert.AreEqual(_posts[0].title, "P4");
            Assert.AreEqual(_posts[1].title, "P5");
        }

    }
}
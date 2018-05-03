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

namespace blog.Controllers.Tests
{
    [TestFixture()]
    public class PostControllerTests
    {
        [Test()]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            Mock<IPostRepository> mock = createMockObject();

            // Arrange
            PostController controller = new PostController(mock.Object);
            controller.pageSize = 3;
            // Act
            PostsListViewModel result = (PostsListViewModel)controller.List(2).Model;
            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.currentPage, 2);
            Assert.AreEqual(pageInfo.itemsPerPage, 3);
            Assert.AreEqual(pageInfo.totalPages, 1);
        }


        [Test()]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IPostRepository> mock = createMockObject();

            PostController controller = new PostController(mock.Object);
            controller.pageSize = 3;
            // Act
            PostsListViewModel result = (PostsListViewModel)controller.List(2).Model;
            // Assert
            Post[] _posts = result.posts.ToArray();
            Assert.IsTrue(_posts.Length == 2);
            Assert.AreEqual(_posts[0].title, "P4");
            Assert.AreEqual(_posts[1].title, "P5");
        }
        private static Mock<IPostRepository> createMockObject()
        {
            Mock<IPostRepository> mock = new Mock<IPostRepository>();
            mock.Setup(m => m.posts).Returns(new List<Post> {
                new Post {idPost = 1, title = "P1"},
                new Post {idPost = 2, title = "P2"},
                new Post {idPost = 3, title = "P3"},
                new Post {idPost = 4, title = "P4"},
                new Post {idPost = 5, title = "P5"}
                });
            return mock;
        }
    }
}
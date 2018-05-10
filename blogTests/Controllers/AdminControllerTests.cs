using NUnit.Framework;
using blog.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using blogBl;
using Moq;
using blogBl.Abstract;
using blogTests;

namespace blog.Controllers.Tests
{
    [TestFixture()]
    public class AdminControllerTests
    {
        [Test()]
        public void IndexTest()
        {
            // Arrange
            Mock<IPostRepository> mock = TestHelper.createMockObject();
            AdminController target = new AdminController(mock.Object);
            // Action
            Post[] result = ((IEnumerable<Post>)target.Index().ViewData.Model).ToArray();
            // Assert
            Assert.AreEqual(result.Length, 5);
            Assert.AreEqual("P1", result[0].title);
            Assert.AreEqual("P2", result[1].title);
            Assert.AreEqual("P3", result[2].title);
            Assert.AreEqual("P4", result[3].title);
            Assert.AreEqual("P5", result[4].title);
        }

        [Test(Description ="can edit existing posts")]
        public void EditTest()
        {
            // Arrange
            Mock<IPostRepository> mock = TestHelper.createMockObject();
            AdminController target = new AdminController(mock.Object);
            // Action
            Post p1 = target.Edit(1).ViewData.Model as Post;
            Post p2 = target.Edit(2).ViewData.Model as Post;
            Post p3 = target.Edit(3).ViewData.Model as Post;
            // Assert
            Assert.AreEqual(1, p1.idPost);
            Assert.AreEqual(2, p2.idPost);
            Assert.AreEqual(3, p3.idPost);
        }

        [Test(Description = "can not edit non existing posts")]
        public void canNotEditTest()
        {
            // Arrange
            Mock<IPostRepository> mock = TestHelper.createMockObject();
            AdminController target = new AdminController(mock.Object);
            // Action
            Post result = target.Edit(50).ViewData.Model as Post;
            // Assert
            Assert.IsNull(result);
        }
    }
}
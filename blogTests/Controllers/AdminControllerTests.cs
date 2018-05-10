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
    }
}
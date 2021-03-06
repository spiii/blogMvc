﻿using NUnit.Framework;
using blog.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using blogTests;
using Moq;
using blogBl.Abstract;

namespace blog.Controllers.Tests
{
    [TestFixture()]
    public class GroupControllerTests
    {
        [Test()]
        public void canCreateGroups()
        {
            // Arrange
            Mock<IPostRepository> mock = TestHelper.createMockObject();
            // Arrange
            GroupController target = new GroupController(mock.Object);
            // Act
            string[] results = ((IEnumerable<string>)target.Menue().Model).ToArray();
            // Assert
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0], "group A");
            Assert.AreEqual(results[1], "group E");
        }
    }
}
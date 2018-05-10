using NUnit.Framework;
using blog.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using blogBl;
using Moq;
using blogBl.Abstract;

namespace blog.helpers.Tests
{
    [TestFixture()]
    public class MockCreatorHelperTests
    {
        [Test()]
        public void createMockObjectTest()
        {
            // Assert
            Assert.IsNotNull(MockCreatorHelper.createMockObject());
        }

        [Test()]
        public void createGroupMockObjectTest()
        {
            //Act
            Mock<IGroupRepository> result = MockCreatorHelper.createGroupMockObject();

            List<Group> groups = new List<Group>();
            MockCreatorHelper.createGroups(groups, 0, 10);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(groups.Count(), result.Object.groups.Count());
        }
    }
}
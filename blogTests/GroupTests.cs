using NUnit.Framework;
using blogBl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace blogBl.Tests
{
    [TestFixture()]
    public class GroupTests
    {
        [Test()]
        public void getCheckedAttributeTest()
        {
            //Arrange
            Group group = new Group { idGroup = 1 };
            List<Group> groups = new List<Group>();
            groups.Add(new Group { idGroup = 1 });

            //Act
            string result = group.getCheckedAttribute(groups);
            //Assert
            Assert.AreEqual(result, "checked");
        }
    }
}
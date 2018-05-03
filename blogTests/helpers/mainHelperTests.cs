using NUnit.Framework;
using blog.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.helpers.Tests
{
    [TestFixture()]
    public class mainHelperTests
    {
        [TestCase(4,true,"D")]
        [TestCase(4,false,"d")]
        [TestCase(5,false,"e")]
        public void Number2StringTest(int position,bool isCap,string result)
        {
            // Act
            string letter=MainHelper.number2String(position, isCap);
            // Assert
            Assert.AreEqual(letter, result);
           
        }
    }
}
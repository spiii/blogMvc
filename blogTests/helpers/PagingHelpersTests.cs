using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using blog.Controllers;
using blog.Models;
using blog.HtmlHelpers;
using NUnit.Framework;

namespace blog.HtmlHelpers.Tests
{
    [TestFixture()]
    public class PagingHelpersTests
    {
        [Test( Description = "LinkPager helper works correct")]
        public void pageLinksTest()
        {
            HtmlHelper myHelper = null;
         
            PagingInfo pagingInfo = new PagingInfo
            {
                currentPage = 2,
                totalPages = 3,
                itemsPerPage = 10
            };

            Func<int, string> pageUrlDelegate = i => "Page" + i;
            // Act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            // Assert
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
            + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
            + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
            result.ToString());
        }
    }
}
using NUnit.Framework;
using blog.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using blogBl;
using blogTests;
using Moq;
using blogBl.Abstract;
using System.Web.Mvc;
using blog.Models;

namespace blog.Controllers.Tests
{
    [TestFixture()]
    public class VotingControllerTests
    {
        [Test()]
        public void voteUpTest()
        {
            // Arrange
            Mock<IPostRepository> mock = TestHelper.createMockObject();
            Voting voting = new Voting();
            VotingController target = new VotingController(mock.Object);

            // Act 
            target.voteUp(voting, 1,null);
            
            // Assert
            Assert.AreEqual(voting.lines.Count(), 1);
            Assert.AreEqual(voting.lines.ToArray()[0].post.idPost, 1);
            Assert.AreEqual(voting.lines.ToArray()[0].upVote, true);
        }

        [Test()]
        public void voteDownTest()
        {
            // Arrange
            Mock<IPostRepository> mock = TestHelper.createMockObject();
            Voting voting = new Voting();
            VotingController target = new VotingController(mock.Object);

            // Act 
            target.voteDown(voting, 1, null);

            // Assert
            Assert.AreEqual(voting.lines.Count(), 1);
            Assert.AreEqual(voting.lines.ToArray()[0].post.idPost, 1);
            Assert.AreEqual(voting.lines.ToArray()[0].upVote, false);
        }


        [Test()]
        public void votePostUpAndShowVoting()
        {
            // Arrange
            Mock<IPostRepository> mock = TestHelper.createMockObject();
            Voting voting = new Voting();
            VotingController target = new VotingController(mock.Object);

            // Act
            RedirectToRouteResult result = target.voteUp(voting, 2, "myUrl");
            // Assert
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "myUrl");
        }

        [Test()]
        public void canViewVotings()
        {
            // Arrange
            Mock<IPostRepository> mock = TestHelper.createMockObject();
            Voting voting = new Voting();
            VotingController target = new VotingController(mock.Object);

            // Act
            VotingIndexViewModel result = (VotingIndexViewModel)target.Index(voting, "myUrl").ViewData.Model;
            // Assert
            Assert.AreSame(result.voting, voting);
            Assert.AreEqual(result.returnUrl, "myUrl");
        }
    }
}
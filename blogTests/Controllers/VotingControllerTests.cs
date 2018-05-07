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
            Mock<IVotingProcessor> mock_p = new Mock<IVotingProcessor>();
            VotingController target = new VotingController(mock.Object, mock_p.Object);

            // Act 
            target.voteUp(voting, 1, null);

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
            Mock<IVotingProcessor> mock_p = new Mock<IVotingProcessor>();
            VotingController target = new VotingController(mock.Object, mock_p.Object);

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
            Mock<IVotingProcessor> mock_p = new Mock<IVotingProcessor>();
            VotingController target = new VotingController(mock.Object, mock_p.Object);

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
            Mock<IVotingProcessor> mock_p = new Mock<IVotingProcessor>();
            VotingController target = new VotingController(mock.Object, mock_p.Object);

            // Act
            VotingIndexViewModel result = (VotingIndexViewModel)target.Index(voting, "myUrl").ViewData.Model;
            // Assert
            Assert.AreSame(result.voting, voting);
            Assert.AreEqual(result.returnUrl, "myUrl");
        }

        [Test()]
        public void cannotSaveEmptyVotings()
        {
            // Arrange
            Mock<IPostRepository> mock = TestHelper.createMockObject();
            Voting voting = new Voting();
            Mock<IVotingProcessor> mock_p = new Mock<IVotingProcessor>();
            VotingController target = new VotingController(mock.Object, mock_p.Object);

            // Act
            ViewResult result = target.save(voting);
            // Assert
            mock_p.Verify(m => m.processVoting(It.IsAny<Voting>()),Times.Never());
            Assert.AreEqual("Completed", result.ViewName);
            Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
        }

        [Test()]
        public void canSaveVotings()
        {
            // Arrange
            Mock<IPostRepository> mock = TestHelper.createMockObject();
            Voting voting = new Voting();
            voting.upVote(new Post(), 1);
            Mock<IVotingProcessor> mock_p = new Mock<IVotingProcessor>();
            VotingController target = new VotingController(mock.Object, mock_p.Object);

            // Act
            ViewResult result = target.save(voting);
            // Assert
            mock_p.Verify(m => m.processVoting(It.IsAny<Voting>()),Times.Once());
            Assert.AreEqual("Completed", result.ViewName);
            Assert.AreEqual(true, result.ViewData.ModelState.IsValid);

        }
    }
}
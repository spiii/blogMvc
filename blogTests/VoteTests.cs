using NUnit.Framework;
using blogBl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogBl.Tests
{
    [TestFixture()]
    public class VoteTests
    {
        [Test()]
        public void addToVoting()
        {
            Post p1, p2;
            int userId = 1;
            createPosts(out p1, out p2);
            Voting target = new Voting();

            // Act
            target.upVote(p1, userId);
            target.upVote(p2, userId);
            VoteLine[] results = target.lines.ToArray();
            // Assert
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].post, p1);
            Assert.AreEqual(results[1].post, p2);
        }

        private static void createPosts(out Post p1, out Post p2)
        {
            // Arrange
            p1 = new Post { idPost = 1, title = "title 1" };
            p2 = new Post { idPost = 2, title = "title 2" };
        }


        [Test()]
        public void canUpVote()
        {
            // Arrange
            Post p1, p2;
            int userId = 1;
            int otherUserId = 2;
            createPosts(out p1, out p2);
            Voting target = new Voting();

            // Act
            target.upVote(p1, otherUserId);
            target.upVote(p1, userId);
            VoteLine[] results = target.lines.ToArray();

            // Assert
            Assert.AreEqual(results[0].quantity, 2);
        }

        [Test()]
        public void canDownVote()
        {
            // Arrange
            Post p1, p2;
            int userId = 1;
            int otherUserId = 2;
            createPosts(out p1, out p2);
            Voting target = new Voting();

            // Act
            target.downVote(p1, otherUserId);
            target.downVote(p1, userId);
            VoteLine[] results = target.lines.ToArray();

            // Assert
            Assert.AreEqual(results[0].quantity, 2);
        }

        [Test()]
        public void removeLinesTest()
        {
            // Arrange
            Post p1, p2;

            createPosts(out p1, out p2);
            Voting target = new Voting();

            // Act
            target.removeLines();
            VoteLine[] results = target.lines.ToArray();

            // Assert
            Assert.AreEqual(results.Count(), 0);
        }
    }
}
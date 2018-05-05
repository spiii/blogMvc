using blogBl;
using blogBl.Abstract;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogTests
{
    public static class TestHelper
    {
        public static Mock<IPostRepository> createMockObject()
        {
            Mock<IPostRepository> mock = new Mock<IPostRepository>();
            mock.Setup(m => m.posts).Returns(new List<Post> {
                new Post {idPost = 1, title = "P1",
                    groups = new List<Group>{
                        new Group {groupName ="group A"} } },
                new Post {idPost = 2, title = "P2",
                    groups = new List<Group>{
                        new Group { groupName = "group E" } } },
                new Post  {idPost = 3, title = "P3",
                    groups = new List<Group>{
                        new Group {groupName ="group A"} } },
                new Post {idPost = 4, title = "P4",
                    groups = new List<Group>{
                        new Group { groupName = "group E" } } },
                new Post {idPost = 5, title = "P5",
                    groups = new List<Group>{
                        new Group {groupName ="group A"} } }
                });
            return mock;
        }

    }
}

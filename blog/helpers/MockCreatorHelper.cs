using blog.helpers;
using blogBl;
using blogBl.Abstract;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.helpers
{
    public static class MockCreatorHelper
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

        public static Mock<IGroupRepository> createGroupMockObject()
        {
            Mock<IGroupRepository> mockGroups = new Mock<IGroupRepository>();
            List<Group> groups = new List<Group>();
            createGroups(groups, 0, 10);

            mockGroups.Setup(m => m.groups).Returns(groups);
            return mockGroups;
        }
        public static List<Post> createPosts(List<Group> groups, List<Group> groupsSec)
        {
            List<Post> posts = new List<Post>();

            for (int i = 0; i < 30; i++)
                posts.Add(new Post { title = $"Post title {i}", idPost = i, groups = i % 2 == 0 ? groups : groupsSec });
            return posts;
        }

        public static void createGroups(List<Group> groups, int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                groups.Add(new Group { groupName = $"group {MainHelper.number2String(i + 1, true)}", idGroup = i });
            }
        }


    }
}

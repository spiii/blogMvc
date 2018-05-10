using blog.Models;
using blogBl;
using blogBl.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blog.Controllers
{
    public class PostController : Controller
    {

        private IPostRepository repository;
        public int pageSize = 4;

        public PostController(IPostRepository postRepository)
        {
            this.repository = postRepository;
        }

        public ViewResult List(string group, int page = 1)
        {
            IEnumerable<Post> filteredPosts = repository.posts
                .Where(p => group == null ||
                (p.groups != null && p.groups.Select(g => g.groupName).Contains(group)));

            PostsListViewModel model = new PostsListViewModel
            {
                posts = filteredPosts
                .OrderBy(p => p.idPost)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    currentPage = page,
                    itemsPerPage = pageSize,
                    totalPages = filteredPosts.Count()/pageSize
                },
                currentGroup = new Group { groupName = group, idGroup = 0 }
            };

            return View(model);
        }
       
    }
}

using blogBl.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blog.Controllers
{
    public class GroupController : Controller
    {
        private IPostRepository repository;

        public GroupController(IPostRepository postRepository)
        {
            this.repository = postRepository;
        }

        // GET: Group
        public PartialViewResult Menue()
        {
            IEnumerable<string> groups = this.repository.posts
                .SelectMany(x => x.groups.Select(y => y.groupName)
                .Distinct()
                .OrderBy(y => y));

            return PartialView(groups);
        }
    }
}
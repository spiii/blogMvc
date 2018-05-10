using blogBl;
using blogBl.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blog.Controllers
{
    public class AdminController : Controller
    {
        private IPostRepository repository;
        private IGroupRepository groupRepository;

        public AdminController(IPostRepository repository, IGroupRepository groupRepository)
        {
            this.repository = repository;
            this.groupRepository = groupRepository;
        }


        public ViewResult Index()
        {
            return View(repository.posts);
        }

        public ViewResult Edit(int idPost)
        {
            ViewBag.allGroups = this.groupRepository.groups.ToList();

            Post posts = repository.posts
            .FirstOrDefault(p => p.idPost == idPost);

            return View(posts);
        }

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                repository.savePost(post);
                TempData["message"] = string.Format("{0} has been saved", post.title);
                return RedirectToAction("Index");
            }
            else
            {
            }
            return View(post);
        }

    }
}
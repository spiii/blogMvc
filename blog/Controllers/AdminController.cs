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

        public AdminController(IPostRepository repository)
        {
            this.repository= repository;
        }


        public ViewResult Index()
        {
            return View(repository.posts);
        }
    }
}
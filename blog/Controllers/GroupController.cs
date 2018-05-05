﻿using blogBl.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.CSharp;


namespace blog.Controllers
{
    public class GroupController : Controller
    {
        private IPostRepository repository;

        public GroupController(IPostRepository postRepository)
        {
            this.repository = postRepository;
        }

        // GET: Menue
        public PartialViewResult Menue(string group = null)
        {
            ViewBag.SelectedGroup = group;

            IEnumerable<string> groups = this.repository.posts
                .SelectMany(x => x.groups.Select(y => y.groupName))
                .Distinct()
                .OrderBy(y => y);

            return PartialView(groups);
        }
    }
}
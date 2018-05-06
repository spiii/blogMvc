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
    public class VotingController : Controller
    {
        private IPostRepository repository;
        public VotingController(IPostRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(Voting voting, string returnUrl)
        {
            return View(new VotingIndexViewModel
            {
                voting = voting,
                returnUrl = returnUrl
            });
        }

        public RedirectToRouteResult voteUp(Voting voting, int idPost, string returnUrl)
        {
            Post post = repository.posts
            .FirstOrDefault(p => p.idPost == idPost);
            if (post != null)
            {
                voting.upVote(post, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult voteDown(Voting voting, int idPost, string returnUrl)
        {
            Post post = repository.posts
             .FirstOrDefault(p => p.idPost == idPost);
            if (post != null)
            {
                voting.downVote(post, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult removeVoting(Voting voting, int idPost, string returnUrl)
        {
            int userId = 1;
            Post post = repository.posts
            .FirstOrDefault(p => p.idPost == idPost);
            if (post != null)
            {
                voting.removeLine(post,userId);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult summary(Voting voting)
        {
            return PartialView(voting);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using blogBl;

namespace blog.Models
{
    public class VotingIndexViewModel
    {
        public string returnUrl { get;  set; }
        public Voting voting { get;  set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using blog.Controllers;
using blogBl;

namespace blog.Models
{
    public class PostsListViewModel
    {
        public IEnumerable<Post> posts;
        public PagingInfo PagingInfo { get; set; }
        public Group currentGroup { get; set; }

        internal void updateTotalPages()
        {
            this.PagingInfo.totalPages = this.posts.Count() / PagingInfo.itemsPerPage;
        }
    }
}
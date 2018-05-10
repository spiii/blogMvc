using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace blogBl
{
    public class Post
    {
        [HiddenInput(DisplayValue = false)]
        public int idPost { get; set; }
        public string title { get; set; }
        [DataType(DataType.MultilineText)]
        public string description { get; set; }
        public List<Group> groups { get; set; }

    }
}

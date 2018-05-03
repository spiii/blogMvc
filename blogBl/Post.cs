using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogBl
{
    public class Post
    {
        public int idPost { get; set; }
        public string title { get; set; }
        public List<Group> groups { get; set; }

    }
}

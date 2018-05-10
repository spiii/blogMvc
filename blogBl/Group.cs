using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace blogBl
{
    public class Group
    {
        public int idGroup { get; set; }
        public string groupName { get; set; }


        public string getCheckedAttribute(IEnumerable<Group> groups)
        {
            bool result = groups.Select(x => x.idGroup).Contains(this.idGroup);
            return result ? "checked" : "";
        }
    }
}
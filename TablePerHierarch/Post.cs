using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablePerHierarch
{
    public abstract class Post
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Body { get; set; }
        public int Score { get; set; }
    }
}

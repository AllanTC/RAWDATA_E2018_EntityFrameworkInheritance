using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablePerType
{
    public class Post
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int Score { get; set; }

        public Question Question { get; set; }
        public Answer Answer { get; set; }

    }
}

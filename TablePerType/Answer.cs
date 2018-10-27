using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablePerType
{
    public class Answer
    {
        public int Id { get; set; }
        public int ParentId { get; set; }

        public Post Post { get; set; }
    }
}

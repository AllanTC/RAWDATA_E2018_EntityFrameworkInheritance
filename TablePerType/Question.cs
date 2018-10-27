using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablePerType
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Post Post { get; set; }
    }
}

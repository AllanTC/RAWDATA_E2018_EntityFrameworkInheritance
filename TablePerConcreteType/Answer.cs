using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablePerConcreteType
{
    public class Answer
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Body { get; set; }
        public int Score { get; set; }
    }
}

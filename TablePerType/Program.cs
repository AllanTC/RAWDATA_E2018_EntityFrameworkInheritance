using System;
using Microsoft.EntityFrameworkCore;

namespace TablePerType
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyTptContext())
            {
                foreach (var q in db.Questions.Include(x => x.Post))
                {
                    Console.WriteLine($"Q(id:{q.Id}, title:{q.Title}, body:{q.Post.Body})");
                }

                foreach (var a in db.Answers.Include(x => x.Post))
                {
                    Console.WriteLine($"A(id:{a.Id}, parentid:{a.ParentId}, body:{a.Post.Body})");
                }
            }
        }
    }
}

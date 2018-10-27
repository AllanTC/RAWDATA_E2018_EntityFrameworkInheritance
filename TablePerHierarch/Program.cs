using System;

namespace TablePerHierarch
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyTphContext())
            {
                foreach (var q in db.Questions)
                {
                    Console.WriteLine($"Q(id:{q.Id}, title:{q.Title}, body:{q.Body})");
                }

                foreach (var a in db.Answers)
                {
                    Console.WriteLine($"A(id:{a.Id}, parentid:{a.ParentId}, body:{a.Body})");
                }
            }
        }
    }
}

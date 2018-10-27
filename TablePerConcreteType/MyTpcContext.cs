using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TablePerConcreteType
{
    public class MyTpcContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;db=inheritance_example;uid=bulskov;pwd=henrik");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().ToTable("questions_tpc");
            modelBuilder.Entity<Question>().Property(x => x.Id).HasColumnName("postid");
            modelBuilder.Entity<Question>().Property(x => x.Title).HasColumnName("title");
            modelBuilder.Entity<Question>().Property(x => x.Body).HasColumnName("body");
            modelBuilder.Entity<Question>().Property(x => x.Score).HasColumnName("score");


            modelBuilder.Entity<Answer>().ToTable("answers_tpc");
            modelBuilder.Entity<Answer>().Property(x => x.Id).HasColumnName("postid");
            modelBuilder.Entity<Answer>().Property(x => x.ParentId).HasColumnName("parentid");
            modelBuilder.Entity<Answer>().Property(x => x.Body).HasColumnName("body");
            modelBuilder.Entity<Answer>().Property(x => x.Score).HasColumnName("score");
        }
    }
}

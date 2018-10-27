using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TablePerType
{
    public class MyTptContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;db=inheritance_example;uid=bulskov;pwd=henrik");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().ToTable("questions_tpt");
            modelBuilder.Entity<Question>().Property(x => x.Id).HasColumnName("postid");
            modelBuilder.Entity<Question>().Property(x => x.Title).HasColumnName("title");
            modelBuilder.Entity<Question>().HasOne(x => x.Post)
                .WithOne(x => x.Question)
                .HasForeignKey<Question>(x => x.Id);

            modelBuilder.Entity<Answer>().ToTable("answers_tpt");
            modelBuilder.Entity<Answer>().Property(x => x.Id).HasColumnName("postid");
            modelBuilder.Entity<Answer>().Property(x => x.ParentId).HasColumnName("parentid");
            modelBuilder.Entity<Answer>().HasOne(x => x.Post)
                .WithOne(x => x.Answer)
                .HasForeignKey<Answer>(x => x.Id);

            modelBuilder.Entity<Post>().ToTable("posts_tpt");
            modelBuilder.Entity<Post>().Property(x => x.Id).HasColumnName("postid");
            modelBuilder.Entity<Post>().Property(x => x.Body).HasColumnName("body");
            modelBuilder.Entity<Post>().Property(x => x.Score).HasColumnName("score");
        }
    }
}

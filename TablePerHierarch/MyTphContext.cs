using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TablePerHierarch
{
    public class MyTphContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;db=inheritance_example;uid=bulskov;pwd=henrik");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().ToTable("posts_tph");
            modelBuilder.Entity<Post>().Property(x => x.Id).HasColumnName("postid");
            modelBuilder.Entity<Post>().Property(x => x.Type).HasColumnName("posttypeid");
            modelBuilder.Entity<Post>().Property(x => x.Body).HasColumnName("body");
            modelBuilder.Entity<Post>().Property(x => x.Score).HasColumnName("score");
            modelBuilder.Entity<Post>().HasDiscriminator(x => x.Type)
                .HasValue<Question>(1)
                .HasValue<Answer>(2);

            modelBuilder.Entity<Question>().Property(x => x.Title).HasColumnName("title");

            modelBuilder.Entity<Answer>().Property(x => x.ParentId).HasColumnName("parentid");
        }
    }
}

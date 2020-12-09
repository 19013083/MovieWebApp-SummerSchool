using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using My_movie_manager.Models;

#nullable disable

namespace My_movie_manager.Models.UserDetail
{
    public partial class UserDetailContext : DbContext
    {
        public UserDetailContext()
        {
        }

        public UserDetailContext(DbContextOptions<UserDetailContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FavoriteMovie).IsUnicode(false);

                entity.Property(e => e.Firstname).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Surname).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<My_movie_manager.Models.movieDetails> movieDetails { get; set; }
    }
}

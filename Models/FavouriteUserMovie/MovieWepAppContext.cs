using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace My_movie_manager.Models.FavouriteUserMovie
{
    public partial class MovieWepAppContext : DbContext
    {
        public MovieWepAppContext()
        {
        }

        public MovieWepAppContext(DbContextOptions<MovieWepAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FavouriteUserMovie> FavouriteUserMovies { get; set; }
        public virtual DbSet<User> Users { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source = summerschoolproject2020.database.windows.net,1433;Initial Catalog=MovieWepApp;Persist Security Info=False;User ID=Sandile;Password=Peenutbutter@101;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavouriteUserMovie>(entity =>
            {
                entity.Property(e => e.MovieId).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavouriteUserMovies)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__favourite__User___628FA481");
            });

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
    }
}

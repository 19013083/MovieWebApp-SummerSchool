using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace My_movie_manager.Models.FavouriteUserMovie
{
    public partial class User
    {
        public User()
        {
            FavouriteUserMovies = new HashSet<FavouriteUserMovie>();
        }

        [Key]
        [Column("User_Id")]
        public int UserId { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [StringLength(225)]
        public string Firstname { get; set; }
        [StringLength(225)]
        public string Surname { get; set; }
        [Column("password")]
        [StringLength(225)]
        public string Password { get; set; }
        [StringLength(255)]
        public string FavoriteMovie { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [InverseProperty(nameof(FavouriteUserMovie.User))]
        public virtual ICollection<FavouriteUserMovie> FavouriteUserMovies { get; set; }
    }
}

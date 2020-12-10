using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace My_movie_manager.Models.MovieManagerModel
{
    public partial class User
    {
        [Key]
        [Column("User_Id")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Enter your email")]
        [StringLength(255)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter your Name")]
        [StringLength(225)]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Enter your Surname")]
        [StringLength(225)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Create a new password")]
        [Column("password")]
        [StringLength(225)]
        public string Password { get; set; }
        [StringLength(255)]
        public string FavoriteMovie { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }
    }
}

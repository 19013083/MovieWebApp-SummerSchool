using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace My_movie_manager.Models.UserDetail
{
    public partial class User
    {
        [Key]
        [Column("User_Id")]
        public int UserId { get; set; }
        [Required(ErrorMessage="Please enter in your email")]
        [StringLength(255)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter in your name")]
        [StringLength(225)]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Please enter in your surname")]
        [StringLength(225)]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please enter in your password!")]
        [Column("password")]
        [StringLength(225)]
        public string Password { get; set; }
        [StringLength(255)]
        public string FavoriteMovie { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }
    }
}

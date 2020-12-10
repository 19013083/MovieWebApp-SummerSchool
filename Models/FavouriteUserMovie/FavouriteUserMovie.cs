using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace My_movie_manager.Models.FavouriteUserMovie
{
    [Table("favouriteUserMovie")]
    public partial class FavouriteUserMovie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("User_Id")]
        public int? UserId { get; set; }
        [StringLength(255)]
        public string MovieId { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("FavouriteUserMovies")]
        public virtual User User { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace My_movie_manager.Models.MovieManagerModel
{
    [Table("favouriteUserMovie")]
    public partial class FavouriteUserMovie
    {
        [Key]
        [Column("User_id")]
        public int? UserId { get; set; }
        [Column("movieId")]
        [StringLength(255)]
        public string MovieId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}

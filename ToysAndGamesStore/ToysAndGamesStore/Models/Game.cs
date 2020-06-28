using System;
using System.ComponentModel.DataAnnotations;

namespace ToysAndGamesStore.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string? Description { get; set; }

        [Range(0,100)]
        public int? AgeRestriction { get; set; }

        [Required]
        [StringLength(50)]
        public string Company { get; set; }

        [Required]
        [Range(0, 1000)]
        public decimal Price { get; set; }
    }
}

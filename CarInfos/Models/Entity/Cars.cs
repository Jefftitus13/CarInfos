﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarInfos.Models.Entity
{
    public class Cars
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Brand { get; set; }

        [Required]
        [StringLength(100)]
        public required string Model { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int Year { get; set; }

        [Required]
        [StringLength(50)]
        public string? Color { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public required int Mileage { get; set; }

        public bool IsAvailable { get; set; }

        // Navigation Property
        public ICollection<Favorite> Favorites { get; set; }

        //Store images
        public string ImagePath { get; set; }
    }
}

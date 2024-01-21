using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Models.Models
{
    public class Game
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(70, ErrorMessage = "Cannot be longer than 70 characters ")]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [MaxLength(40, ErrorMessage = "Cannot be longer than 40 characters ")]
        public string DevStudio { get; set; }
        [Required]
        public int GameCategoryId { get; set; }
        [ForeignKey("GameCategoryId")]
        [ValidateNever]
        public GameCategory GameCategory { get; set; }



        [Range(1, 400, ErrorMessage = $"Price must be between 1 and 400 {"$"} ")]
        [Required]

        public double PriceSteam { get; set; }
        [Range(1, 400, ErrorMessage = $"Price must be between 1 and 400 {"$"} ")]
        [Required]
        public double PriceXbox { get; set; }
        [Range(1, 400, ErrorMessage = $"Price must be between 1 and 400 {"$"} ")]
        [Required]
        public double PricePS { get; set; }
        [Url]
        [ValidateNever]
        public string? ImageUrl { get; set; }
        [Url]
        [ValidateNever]
        public string? TrailerUrl { get; set; }





    }
}

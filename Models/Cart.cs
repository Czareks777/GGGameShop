using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  Id { get; set; }
        
        public int GameId { get; set; }
        [ForeignKey("GameId")]
        [ValidateNever]
        public Game Game { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public User User { get; set; }
        [NotMapped]
        public int Price { get; set; }
    }
}

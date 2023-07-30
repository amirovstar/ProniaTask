using System;
using System.ComponentModel.DataAnnotations;

namespace P137PRONIA2.Models
{
    public class ProductImage : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}


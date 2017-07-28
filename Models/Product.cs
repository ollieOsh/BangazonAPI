using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public int ProductTypeId { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Title {get; set; }
        [Required]
        public string Description { get; set; }
 
        public int CustomerId { get; set; }
        public virtual Customer Customer

        public ICollection<OrderProduct> OrderProducts;
    }
}

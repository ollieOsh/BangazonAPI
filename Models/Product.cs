using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class: Product
 * Purpose: The Product class is used to store all product information
 * Author: Teamname-Teamname-Teamname
 * Properties:
 *   ProductId: A unique idetification number for each product
     ProductTypeId: The unique identification number of the product type associated with this product
     Product Type: The name of the product type
     Price: The price of the specified product
     Title: The name of the specified product
     Description: A short description of the specified product
     CustomerId: The unique identification number for the customer
     Customer: The customer information
     OrderProducts: A collection of OrderProducts to allow database traversing
 */

namespace BangazonAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public int ProductTypeId { get; set; }
        public ProductType ProductType {get; set;}
        [Required]
        public double Price { get; set; }
        [Required]
        public string Title {get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer {get;set;}

        public ICollection<OrderProduct> OrderProducts;
    }
}
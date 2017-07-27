using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class: ProductType
 * Purpose: The ProductType class is used to store all product type information
 * Author: Teamname-Teamname-Teamname
 * Properties:
 *   ProductTypeId: A unique idetification number for each product type 
     ProductTypeName: The name of the product type
 */

namespace BangazonAPI.Models
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        [Required]
        public string ProductTypeName {get; set;} 
    }
}
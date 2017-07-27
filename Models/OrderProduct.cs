using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class: OrderProduct
 * Purpose: The OrderProduct class is used to store all order/product information (from the join table).
 * Author: Teamname-Teamname-Teamname
 * Properties:
 *   OrderProductId: A unique idetification number for each order 
     OrderId: The order created by the customer
     Order: All of the order information
     ProductId: The specific product included in this order
     Product: The name of the product included in this order
 */

namespace BangazonAPI.Models
{
  public class OrderProduct
  {
    [Key]
    public int OrderProductId { get; set; }

    [Required]
    public int OrderId { get; set; }
    public Order Order { get; set; }

    [Required]
    public int ProductId { get; set; }
    public Product Product { get; set; }
  }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class: Order
 * Purpose: The Order class is used to store all order information.
 * Author: Teamname-Teamname-Teamname
 * Properties:
 *   OrderId: A unique idetification number for each order 
     CustomerId: The customer who created/completed this order
     Customer: All of the customer information that has created/completed this order
     PaymentTypeId: The specific payment that was used for this order. This also indicates whether this is a current order, or a completed order. If the PaymentTypeId is null, the payment is current, if it has a value then the order has been completed by the user. 
     PaymentType: The type of payment used to complete the order
     OrderProducts: A collection of OrderProducts to allow database traversing
 */

namespace BangazonAPI.Models
{
  public class Order
  {
    [Key]
    public int OrderId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime DateCreated { get; set; }

    [Required]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int? PaymentTypeId { get; set;} // ? means that the variable can be null
    public PaymentType PaymentType { get; set; }
    public ICollection<OrderProduct> OrderProducts {get; set;}

  }
}
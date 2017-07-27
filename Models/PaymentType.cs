using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class: PaymentType
 * Purpose: The PaymentType class is used to store all payment type information
 * Author: Teamname-Teamname-Teamname
 * Properties:
 *   PaymentTypeId: A unique idetification number for each payment type 
     CustomerId: The specific customer associated with this PaymentTypeId
     AccountNumber: The account number associated with this PaymentTypeId
     PaymentTypeName: The name of the payment type
 */

namespace BangazonAPI.Models
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }

        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int AccountNumber { get; set; }
        [Required]
        public string PaymentTypeName { get; set; }
    }
}
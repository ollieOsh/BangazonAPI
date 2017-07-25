using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class: Customer
 * Purpose: The Customer class is used to store all customer information.
 * Author: Teamname-Teamname-Teamaname
 * Properties:
 *   CustomerId: A unique idetification number for each customer
     AccountCreated: Date the customer created an account
     LastActivity: Date the customer last logged in
     FirstName: Customer's first name
     LastName: Customer's last name
 */

namespace BangazonAPI.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime AccountCreated { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime LastActivity { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
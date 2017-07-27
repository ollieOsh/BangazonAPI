using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class: Computer
 * Purpose: The Computer class is used to store all computer information.
 * Author: Teamname-Teamname-Teamaname
 * Properties:
 *   ComputerId: A unique idetification number for each employee 
     PurchaseDate: Date the computer was acquired
     DecommissionDate: Date on which the computer shall be put down
     EmployeeComputer: Collection of joint information from the Employee and Computer tables (joint table detailing which employee was assigned which computer and when)
 */

namespace BangazonAPI.Models
{
    public class Computer
    {
        [Key]
        public int ComputerId {get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate {get; set;}
        [Required]
        [DataType(DataType.Date)]

        public DateTime DecommissionDate {get; set;}

        public ICollection <EmployeeComputer> EmployeeComputer;
        
        public Computer()
        {
            PurchaseDate = DateTime.Now;
            DecommissionDate = PurchaseDate.AddYears(2);
        }
    }
}
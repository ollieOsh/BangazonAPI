using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class: EmployeeComputer
 * Purpose: The EmployeeComputer class is used to store all joint employee/computer information.
 * Author: Teamname-Teamname-Teamaname
 * Properties:
 *   EmployeeComputerId: A unique idetification number for each employee/computer relationship
     ComputerId: A unique idetification number for each computer
     EmployeeId: A unique idetification number for each employee
     PurchaseDate: Date the computer was acquired
     StartDate: Date on which the computer was assigned to the employee
     EndDate: Date on which the computer was removed from the employee
 */

namespace BangazonAPI.Models
{
    public class EmployeeComputer
    {
        [Key]
        public int EmployeeComputerId {get; set;}
        [Required]
        public int ComputerId {get; set;}
        public virtual Computer Computer {get; set;} 
        
        [Required]
        public int EmployeeId {get; set;}
        public virtual Employee Employee {get; set; }

        
        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime StartDate {get; set;}

        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime EndDate {get; set;}


    }
}

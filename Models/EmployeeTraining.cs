using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class: EmployeeTraining
 * Purpose: The EmployeeTraining class is used to store all joint employee/training information.
 * Author: Teamname-Teamname-Teamaname
 * Properties:
 *   EmployeeTrainingId: A unique idetification number for each employee/training relationship
     EmployeeId: A unique idetification number for each employee
     Employee: The reference to the employee associated with this employee/training relationship
     TrainingId: A unique idetification number for each training
     Training: The reference to the training associated with this employee/training relationship
     
 */

namespace BangazonAPI.Models
{
    public class EmployeeTraining
    {
        [Key]
        public int EmployeeTrainingId {get; set;}
        [Required]
        public int EmployeeId {get; set;}
        [Required]
        public Employee Employee { get; set; }
        [Required]
        public int TrainingId {get; set; }
        public Training Training { get; set; }

    }
}
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
     TrainingId: A unique idetification number for each training
     
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
        public int TrainingId {get; set; }

    }
}
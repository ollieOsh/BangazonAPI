using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/**
 * Class: Department
 * Purpose: The Department class is used to store all department information.
 * Author: Teamname-Teamname-Teamaname
 * Properties:
 *   DepartmentId: A unique idetification number for each department
     DeptName: Name of the department
     ExpenseBudget: Amount of money the department has at its disposal
 */

namespace BangazonAPI.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId {get; set;}

        [Required]
        public string DeptName {get; set;}
        [Required]
        public int ExpenseBudget {get; set;}
    }
}
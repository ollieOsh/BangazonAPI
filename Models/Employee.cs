using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class: Employee
 * Purpose: The Employee class is used to store all employee information.
 * Author: Ollie - Teamname-Teamname-Teamaname
 * Properties:
 *   EmployeeId: A unique idetification number for each employee 
     EmployeeName: First/Last Name of the employee
     EmployeePhone: Phone number for employee
     DeptId: The department to which the employee is designated
     IsSupervisor: Boolean indicating whether the employee is the supervisor of their department
 */

namespace BangazonAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId {get; set;}
        [Required]
        public string EmployeeName {get; set;}
        [Required]
        public string EmployeePhone {get; set;}
        [Required]
        public int? DeptId {get; set;}
        public Department Department {get; set;}
        [Required]
        public bool IsSupervisor {get; set;}
        public ICollection<EmployeeTraining> EmployeeTrainings;
        public ICollection <EmployeeComputer> EmployeeComputer;

    }
}
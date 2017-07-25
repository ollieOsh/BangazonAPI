using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int DeptId {get; set;}
        [Required]
        public bool IsSupervisor {get; set;}

    }
}
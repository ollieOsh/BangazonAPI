using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
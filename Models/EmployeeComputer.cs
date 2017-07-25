using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
    public class EmployeeComputer
    {
        [Key]
        public int EmployeeComputerId {get; set;}
        [Required]
        public int ComputerId {get; set;}
        [Required]
        public int EmployeeId {get; set;}
        
        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime StartDate {get; set;}

        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime EndDate {get; set;}


    }
}
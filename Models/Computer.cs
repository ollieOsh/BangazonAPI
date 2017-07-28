using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
    public class Computer
    {
        [Key]
        public int ComputerId {get; set; }
        
        [Required]
        public int ModelNumber {get; set;}
        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime PurchaseDate {get; set;}
        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DecommissionDate {get; set;}

        public ICollection <EmployeeComputer> EmployeeComputer;
    }
}
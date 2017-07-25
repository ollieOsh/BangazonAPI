using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonAPI.Models
{
    public class Training
    {
        [Key]
        public int TrainingId {get; set;}

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime StartDate {get; set;}
        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime EndDate {get; set; }
        [Required]
        public int MaxAttendees { get; set; }

        public ICollection<EmployeeTraining> EmployeeTrainings;
    }
}
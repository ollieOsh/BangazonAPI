using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/**
 * Class: Training
 * Purpose: The Training class is used to store all training information
 * Author: Teamname-Teamname-Teamname
 * Properties:
 *   TrainingId: A unique idetification number for each training
     StartDate: The date when the training starts
     EndDate: The date when the training ends
     MaxAttendees: The maximum allowable amount of attendees for the training
     EmployeeTrainings: A collection of EmployeeTrainings to allow database traversing
 */

namespace BangazonAPI.Models
{
    public class Training
    {
        [Key]
        public int TrainingId {get; set;}

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate {get; set;}
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate {get; set; }
        [Required]
        public string Name {get; set;}
        [Required]
        public int MaxAttendees { get; set; }

        public ICollection<EmployeeTraining> EmployeeTrainings;

        public Training()
        {
            EndDate = StartDate.AddMonths(3);
        }
    }
}
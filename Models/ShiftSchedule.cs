using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointment.Models
{
    public class ShiftSchedule
	{
        [Key]
        public string? Id { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("Schedule")]
        public string? ScheduleId { get; set; }

        [ForeignKey("Shift")]
        public string? ShiftId { get; set; }

        public virtual Shift? Shift { get; set; }
        public virtual Schedule? Schedule { get; set; }
    }
}


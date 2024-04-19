using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Models
{
	public class Shift
	{
        [Key]
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public string? TimeSlot { get; set; }
    }
}


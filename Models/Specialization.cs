using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointment.Models
{
	public class Specialization
	{
		[Key]
		public string? Id { get; set; } = Guid.NewGuid().ToString();
        [MaxLength(200)]
        public string? Name { get; set; }
		public string? Description { get; set; }
    }
}


using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MedicalAppointment.Models
{
	public class ApplicationUser : IdentityUser
	{
        [MaxLength(200)]
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(30)]
        public string? Gender { get; set; }
        [MaxLength(300)]
        public string? Address { get; set; }
        [MaxLength(500)]
        public string? Image { get; set; }
    }
}

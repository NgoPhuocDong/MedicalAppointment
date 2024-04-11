using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointment.Models
{
	public class UserSpecialization
	{
        public string ? UserId { get; set; }

        public string ? SpecializeId { get; set; }

        public virtual ApplicationUser? User { get; set; }
        public virtual Specialization? Specialization { get; set; }

    }
}


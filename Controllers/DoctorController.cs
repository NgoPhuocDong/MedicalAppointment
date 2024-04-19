using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MedicalAppointment.Data;
using MedicalAppointment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointment.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DoctorController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index(string inputsearch)
        {
            ViewData["Specialize"] = new SelectList(_context.Specializations, "Id", "Name");

            if (String.IsNullOrEmpty(inputsearch))
            {
                var doctor = await _context.Doctors
                .Include(m => m.User)
                .Include(m => m.Specialization)
                .Where(m => m.User != null && m.User.UserRoles != null && m.User.UserRoles.Any(ur => ur.Role != null && ur.Role.Name == "Doctor"))
                .ToListAsync();
                return View(doctor);
            }
            else
            {
                var doctor = await _context.Doctors
                .Include(m => m.User)
                .Include(m => m.Specialization)
                .Where(m => m.User != null && m.User.UserRoles != null && m.User.UserRoles.Any(ur => ur.Role != null && ur.Role.Name == "Doctor"))
                .Where(m => m.User.FullName.ToLower().Contains(inputsearch.ToLower())
                    || m.Specialization.Name.ToLower().Contains(inputsearch.ToLower())
                    || string.IsNullOrEmpty(inputsearch) == true
                    || m.User.Gender.ToLower().Contains(inputsearch.ToLower()))
                .ToListAsync();
                return View(doctor);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetFilteredDoctor(string gender)
        {
            
            var doctor = await _context.Doctors
            .Include(m => m.User)
            .Include(m => m.Specialization)
            .Where(m => m.User != null && m.User.UserRoles != null && m.User.UserRoles.Any(ur => ur.Role != null && ur.Role.Name == "Doctor"))
            .Where(m => m.User.Gender.ToLower().Contains(gender.ToLower())
                    || string.IsNullOrEmpty(gender) == true)
            .ToListAsync();
            return PartialView("_DoctorList", doctor);
            
        }
           
    }
}
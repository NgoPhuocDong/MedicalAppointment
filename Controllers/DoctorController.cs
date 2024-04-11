using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalAppointment.Data;
using MedicalAppointment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index()
        {
            var listUser = await _context.Users
                .Include(m => m.UserRoles)
                .Where(u => u.UserRoles != null && u.UserRoles.Any(r => r.Role != null && r.Role.Name == "Doctor"))
                .ToListAsync();
            return View(listUser);
        }
    }
}
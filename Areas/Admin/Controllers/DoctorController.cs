using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalAppointment.Data;
using MedicalAppointment.Models;
using MedicalAppointment.Models.ViewModels;
using System.Numerics;
using Microsoft.SqlServer.Server;

namespace MedicalAppointment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Doctor
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Doctors.Include(d => d.Specialization).Include(d => d.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Doctor/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Doctors == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .Include(d => d.Specialization)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        // GET: Admin/Doctor/Create
        public IActionResult Create()
        {
            ViewData["SpecializationId"] = new SelectList(_context.Specializations, "Id", "Name");

            ViewData["UserId"] = new SelectList(_context.Users.Include(m => m.UserRoles)
                                                                .Where(u => u.UserRoles != null && u.UserRoles
                                                                .Any(r => r.Role != null && r.Role.Name == "Doctor")), "Id", "FullName");
            return View();
        }

        // POST: Admin/Doctor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,SpecializationId")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpecializationId"] = new SelectList(_context.Specializations, "Id", "Name", doctor.SpecializationId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", doctor.UserId);
            return View(doctor);
        }

        // GET: Admin/Doctor/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Doctors == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors.FirstOrDefaultAsync(m => m.UserId == id);
            if (doctor == null)
            {
                return NotFound();
            }
            ViewData["SpecializationId"] = new SelectList(_context.Specializations, "Id", "Name", doctor.SpecializationId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", doctor.UserId);
            return View(doctor);
        }

        // POST: Admin/Doctor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,SpecializationId")] Doctor doctor)
        {
            if (id != doctor.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpecializationId"] = new SelectList(_context.Specializations, "Id", "Name", doctor.SpecializationId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName", doctor.UserId);
            return View(doctor);
        }

        // GET: Admin/Doctor/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Doctors == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .Include(d => d.Specialization)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Admin/Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Doctors == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Doctors'  is null.");
            }
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //Xếp lịch
        //public IActionResult SetShift(string id)
        //{
        //    ViewData["UserId"] = new SelectList(_context.Users.Include(m => m.UserRoles)
        //                                                        .Where(u => u.UserRoles != null && u.UserRoles
        //                                                        .Any(r => r.Role != null && r.Role.Name == "Doctor")), "Id", "FullName");
        //    return View();
        //}

        // POST: Admin/Schedule/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> SetShift([Bind("UserId,AppointmentDate,TimeSlot")] ShiftScheduleVM scheduleVM)
        //{
         
        //    ViewData["UserId"] = new SelectList(_context.Users.Include(m => m.UserRoles)
        //                                                        .Where(u => u.UserRoles != null && u.UserRoles
        //                                                        .Any(r => r.Role != null && r.Role.Name == "Doctor")), "Id", "FullName", scheduleVM.UserId);
        //    if (ModelState.IsValid)
        //    {
        //        Schedule schedule = new Schedule();
        //        schedule.UserId = scheduleVM.UserId;
        //        schedule.AppointmentDate = scheduleVM.AppointmentDate;
        //        _context.Schedules.Add(schedule);
        //        await _context.SaveChangesAsync();
        //        //return RedirectToAction(nameof(Index));
        //        try
        //        {
        //            Shift shift = new Shift();
        //            shift.ScheduleId = schedule.Id;
        //            shift.TimeSlot = scheduleVM.TimeSlot;
                    
        //            _context.Shifts.Add(shift);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            ViewData["ErrorMessager"] = "Đã xảy ra lỗi! vui lòng kiểm tra thông tin đã nhập";
        //            return View(scheduleVM);
        //        }
        //    }
            
        //    ViewData["ErrorMessager"] = "Đã xảy ra lỗi! vui lòng kiểm tra thông tin đã nhập";
        //    return View(scheduleVM);
        //}

        
        //[HttpPost]
        //public JsonResult GrantShift(string UserId, DateTime Date ,List<string> TimeSlot)
        //{
        //    try
        //    {
        //        Schedule schedule = new Schedule();
        //        schedule.UserId = UserId;
        //        schedule.AppointmentDate = Date;
        //        _context.Schedules.Add(schedule);
        //        _context.SaveChanges();

        //        // Kiểm tra ScheduleId không null trước khi sử dụng
        //        if (schedule.Id != null)
        //        {
        //            foreach (var time in TimeSlot)
        //            {
        //                Shift shift = new Shift();
        //                shift.ScheduleId = schedule.Id;
        //                shift.TimeSlot = time;
        //                _context.Shifts.Add(shift);
        //                _context.SaveChanges();
        //            }
        //        }
        //        else
        //        {
        //            // Xử lý trường hợp ScheduleId không được gán giá trị
        //            return Json(new { status = "Error", message = "ScheduleId is null" });
        //        }
        //        return Json(new { status = "Success" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { status = "Error", message = ex.Message });
        //    }
        //}
        public IActionResult SetCalendar(string id)
        {
            ViewData["UserId"] = new SelectList(_context.Users.Include(m => m.UserRoles)
                                                                .Where(u => u.UserRoles != null && u.UserRoles
                                                                .Any(r => r.Role != null && r.Role.Name == "Doctor")), "Id", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetCalendar([Bind("UserId,AppointmentDate")] ShiftScheduleVM scheduleVM, List<string>TimeSlot)
        {

            ViewData["UserId"] = new SelectList(_context.Users.Include(m => m.UserRoles)
                                                        .Where(u => u.UserRoles != null && u.UserRoles
                                                        .Any(r => r.Role != null && r.Role.Name == "Doctor")), "Id", "FullName", scheduleVM.UserId);

            if (ModelState.IsValid)
            {
                try
                {
                    Schedule schedule = new Schedule
                    {
                        UserId = scheduleVM.UserId,
                        AppointmentDate = scheduleVM.AppointmentDate
                    };

                    _context.Schedules.Add(schedule);
                    await _context.SaveChangesAsync();

                    // Thêm các ca trực mới vào cơ sở dữ liệu
                    foreach (var timeSlot in TimeSlot)
                    {
                        Shift shift = new Shift
                        {
                            ScheduleId = schedule.Id,
                            TimeSlot = timeSlot // Sử dụng chuỗi đã chuyển đổi
                        };

                        _context.Shifts.Add(shift);
                    }

                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ViewData["ErrorMessager"] = "Đã xảy ra lỗi! Vui lòng kiểm tra thông tin đã nhập.";
                    return View(scheduleVM);
                }
            }
            ViewData["ErrorMessager"] = "Đã xảy ra lỗi! Vui lòng kiểm tra thông tin đã nhập.";
            return View(scheduleVM);

        }
        private bool DoctorExists(string id)
        {
            return (_context.Doctors?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
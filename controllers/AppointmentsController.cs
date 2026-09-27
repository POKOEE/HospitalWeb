using HospitalWeb.Data;
using HospitalWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HospitalWeb.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly HospitalContext _context;
        public AppointmentsController(HospitalContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var appts = _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor);
            return View(await appts.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Patients = new SelectList(_context.Patients, "Id", "FullName");
            ViewBag.Doctors = new SelectList(_context.Doctors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientId,DoctorId,AppointmentDate,Notes")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Patients = new SelectList(_context.Patients, "Id", "FullName", appointment.PatientId);
            ViewBag.Doctors = new SelectList(_context.Doctors, "Id", "FullName", appointment.DoctorId);
            return View(appointment);
        }
    }
}
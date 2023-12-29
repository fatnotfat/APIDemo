using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using Services.Interfaces;
using AutoMapper;
using Health360Scheduler.DataTransferObjects;
using Services;
using Health360Scheduler.Mappers;

namespace Health360Scheduler.Controllers.DoctorsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorServices;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorServices = doctorService;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetDoctorsAsync()
        {

            //create map
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DoctorProfile());
            });
            var mapper = config.CreateMapper();
            //End create map

            //transfer from doctor to doctor dto

            var data = await _doctorServices.GetAllDoctorsAsync();
            var doctorDTOs = data.Select(
                             doc => mapper.Map<Doctor, DoctorDTO>(doc)
                           );
            if (await _doctorServices.GetAllDoctorsAsync() == null)
            {
                return NotFound();
            }
            return Ok(doctorDTOs);
        }

        //// GET: api/Doctors/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Doctors>> GetDoctors(Guid id)
        //{
        //  if (_context.Doctors == null)
        //  {
        //      return NotFound();
        //  }
        //    var doctors = await _context.Doctors.FindAsync(id);

        //    if (doctors == null)
        //    {
        //        return NotFound();
        //    }

        //    return doctors;
        //}

        // PUT: api/Doctors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDoctors(Guid id, Doctors doctors)
        //{
        //    if (id != doctors.DoctorID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(doctors).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DoctorsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Doctors
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Doctors>> PostDoctors(Doctors doctors)
        //{
        //  if (_context.Doctors == null)
        //  {
        //      return Problem("Entity set 'Health360SchedulerDBContext.Doctors'  is null.");
        //  }
        //    _context.Doctors.Add(doctors);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDoctors", new { id = doctors.DoctorID }, doctors);
        //}

        //// DELETE: api/Doctors/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDoctors(Guid id)
        //{
        //    if (_context.Doctors == null)
        //    {
        //        return NotFound();
        //    }
        //    var doctors = await _context.Doctors.FindAsync(id);
        //    if (doctors == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Doctors.Remove(doctors);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool DoctorsExists(Guid id)
        //{
        //    return (_context.Doctors?.Any(e => e.DoctorID == id)).GetValueOrDefault();
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hellosas.Controllers.Models;
using hellosas.Data;
using hellosas.Repository;
using Microsoft.Extensions.Logging;
using log4net.Core;
using log4net.Repository.Hierarchy;
using Microsoft.VisualBasic;
using System.Collections;

namespace hellosas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class coursesController : ControllerBase
    {
        private readonly hellosasContext _context;
        private readonly IcourseRepository _courseRepository;
        private readonly ILogger<coursesController> _logger;


        public coursesController(hellosasContext context, ILogger<coursesController> logger,IcourseRepository courseRepository)
        {
            _context = context;
            _logger = logger;
            _courseRepository = courseRepository;


        }

        // GET: api/courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<course>>> Getcourse()
        {
            //return await _context.course.ToListAsync();
            //_logger.LogInformation("getting all users sucessfully");
            return await _courseRepository.Getcourse();

        }

        // GET: api/courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<course>> Getcourse(int id)
        {
            //var course = await _context.course.FindAsync(id);

            //if (course == null)
            //{
            //    return NotFound();
            //}

            //return course;
            try
            {
                return await _courseRepository.Getcourse(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        //[HttpGet("name/{name}")]
        //public async Task<ActionResult<course>> GetcourseByName(string name)
        //{
        //    try
        //    {
        //        return await _courseRepository.GetcourseByName(name);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        return NotFound();
        //    }
        //}

        // PUT: api/courses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcourse(int id, course course)
        {
            if (id != course.courseid)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!courseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
           // _logger.LogInformation("User updated successfully.");
            return NoContent();
        }

        // POST: api/courses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<course>> Postcourse(course course)
        {
            //_context.course.Add(course);
            //await _context.SaveChangesAsync();
            await _courseRepository.Postcourse(course);


            return CreatedAtAction("Getcourse", new { id = course.courseid }, course);
        }

        // DELETE: api/courses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<course>> Deletecourse(int id)
        {
            //var course = await _context.course.FindAsync(id);
            //if (course == null)
            //{
            //    return NotFound();
            //}

            //_context.course.Remove(course);
            //await _context.SaveChangesAsync();

            //return course;
            try
            {
                return await _courseRepository.Deletecourse(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        private bool courseExists(int id)
        {
            return _context.course.Any(e => e.courseid == id);
        }
    }
}

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using hellosas.Controllers.Models;
using hellosas.Data;
using System.Linq;

namespace hellosas.Repository
{
    public class courseRepository : IcourseRepository
    {
        private readonly hellosasContext _context;
        private readonly ILogger<courseRepository> _logger;

        public courseRepository(hellosasContext context, ILogger<courseRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ActionResult<IEnumerable<course>>> Getcourse()
        {
            _logger.LogInformation("Getting all the users sucessfully");
            return await _context.course.ToListAsync();
        }
        public async Task<ActionResult<course>> Getcourse(int id)
        {
            var course = await _context.course.FindAsync(id);
            if (course== null)
            {
                throw new NullReferenceException("sorry, no course found with this id " + id);
            }
            else
            {
                return course;
            }
        }

        //public async Task<ActionResult<course>> GetcourseByName(string name)
        //{
        //    var course = await _context.course.FindAsync(name);
        //    if (course == null)
        //    {
        //        throw new NullReferenceException("sorry, no course found with this name " + name);
        //    }
        //    else
        //    {
        //        return course;
        //    }
        //}

        public async Task<ActionResult<course>> Putcourse(int id, string name)
        {
            var course = await _context.course.FirstOrDefaultAsync(x => x.courseid== id && x.coursename== name);
            if (course == null)
            {
                throw new NullReferenceException("sorry, no course is available");
            }
            else
            {
                return course;
            }
        }
        public async Task<ActionResult<course>> Postcourse(course course)
        {
            _context.course.Add(course);
            await _context.SaveChangesAsync();
            _logger.LogInformation("course created sucessfully");

            return course;
        }

        public async Task<ActionResult<course>> Deletecourse(int id)
        {
            var course = await _context.course.FindAsync(id);
            if (course == null)
            {
                throw new NullReferenceException("sorry, no course found with this id " + id);
            }
            else
            {
                _context.course.Remove(course);
                await _context.SaveChangesAsync();
                _logger.LogInformation("course deleted sucessfully");

                return course;
            }
        }
        public bool courseExists(int id)
        {
            return _context.course.Any(e => e.courseid == id);
        }





    }
}

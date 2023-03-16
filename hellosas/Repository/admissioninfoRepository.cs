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
    public class admissioninfoRepository : IadmissioninfoRepository
    {
        private readonly hellosasContext _context;
        private readonly ILogger<admissioninfoRepository> _logger;

        public admissioninfoRepository(hellosasContext context, ILogger<admissioninfoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ActionResult<IEnumerable<admissioninfo>>> Getadmissioninfo()
        {
            _logger.LogInformation("Getting all the users sucessfully");
            return await _context.admissioninfo.ToListAsync();
        }
        public async Task<ActionResult<admissioninfo>> Getadmissioninfo(int id)
        {
            var admissioninfo = await _context.admissioninfo.FindAsync(id);
            if (admissioninfo == null)
            {
                throw new NullReferenceException("sorry, no user found with this id " + id);
            }
            else
            {
                return admissioninfo;
            }
        }
        public async Task<ActionResult<admissioninfo>> Postadmissioninfo( admissioninfo admissioninfo)
        {
            _context.admissioninfo.Add(admissioninfo);
            await _context.SaveChangesAsync();
            _logger.LogInformation("User created sucessfully");

            return admissioninfo;
        }

        public async Task<ActionResult<admissioninfo>> Deleteadmissioninfo(int id)
        {
            var admissioninfo = await _context.admissioninfo.FindAsync(id);
            if (admissioninfo == null)
            {
                throw new NullReferenceException("sorry, no user found with this id " + id);
            }
            else
            {
                _context.admissioninfo.Remove(admissioninfo);
                await _context.SaveChangesAsync();
                _logger.LogInformation("user deleted sucessfully");

                return admissioninfo;
            }
        }
        public bool admissioninfoExists(int id)
        {
            return _context.admissioninfo.Any(e => e.addid == id);
        }




    }
}

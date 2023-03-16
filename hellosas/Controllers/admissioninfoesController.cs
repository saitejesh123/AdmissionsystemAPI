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

namespace hellosas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class admissioninfoesController : ControllerBase
    {
        private readonly hellosasContext _context;
        private readonly IadmissioninfoRepository _admissioninfoRepository;
        private readonly ILogger<admissioninfoesController> _logger;


        public admissioninfoesController(hellosasContext context, ILogger<admissioninfoesController> logger, IadmissioninfoRepository admissioninfoRepository)
        {
            _context = context;
            _logger = logger;
            _admissioninfoRepository = admissioninfoRepository;

        }

        // GET: api/admissioninfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<admissioninfo>>> Getadmissioninfo()
        {
            // return await _context.admissioninfo.ToListAsync();
            //_logger.LogInformation("getting all users sucessfully");
            return await _admissioninfoRepository.Getadmissioninfo();

        }

        // GET: api/admissioninfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<admissioninfo>> Getadmissioninfo(int id)
        {
        //    var admissioninfo = await _context.admissioninfo.FindAsync(id);

        //    if (admissioninfo == null)
        //    {
        //        return NotFound();
        //    }

        //    return admissioninfo;
         try
            {
                return await _admissioninfoRepository.Getadmissioninfo(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
}
        }

        // PUT: api/admissioninfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putadmissioninfo(int id, admissioninfo admissioninfo)
        {
            if (id != admissioninfo.addid)
            {
                return BadRequest();
            }

            _context.Entry(admissioninfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!admissioninfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            _logger.LogInformation("User updated successfully.");
            return NoContent();
        }

        // POST: api/admissioninfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<admissioninfo>> Postadmissioninfo(admissioninfo admissioninfo)
        {
            //_context.admissioninfo.Add(admissioninfo);
            //await _context.SaveChangesAsync();
            await _admissioninfoRepository.Postadmissioninfo(admissioninfo);


            return CreatedAtAction("Getadmissioninfo", new { id = admissioninfo.addid }, admissioninfo);
        }

        // DELETE: api/admissioninfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<admissioninfo>> Deleteadmissioninfo(int id)
        {
            //var admissioninfo = await _context.admissioninfo.FindAsync(id);
            //if (admissioninfo == null)
            //{
            //    return NotFound();
            //}

            //_context.admissioninfo.Remove(admissioninfo);
            //await _context.SaveChangesAsync();

            //return admissioninfo;
            try
            {
                return await _admissioninfoRepository.Getadmissioninfo(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        private bool admissioninfoExists(int id)
        {
            return _context.admissioninfo.Any(e => e.addid == id);
        }
    }
}

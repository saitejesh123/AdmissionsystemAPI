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
using log4net.Core;
using Microsoft.Extensions.Logging;
using log4net.Repository.Hierarchy;
using Microsoft.VisualBasic;
using System.Collections;

namespace hellosas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class stdinfoesController : ControllerBase
    {
        private readonly hellosasContext _context;
        private readonly IstdinfoRepository _stdinfoRepository;
        private readonly ILogger<stdinfoesController> _logger;


        public stdinfoesController(hellosasContext context,ILogger<stdinfoesController> logger ,IstdinfoRepository stdinfoRepository)
        {
            _context = context;
            _logger = logger;
            _stdinfoRepository = stdinfoRepository;

        }

        // GET: api/stdinfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<stdinfo>>> Getstdinfo()
        {
            //_logger.LogInformation("getting all users sucessfully");
           // return await _context.stdinfo.ToListAsync();
            return await _stdinfoRepository.Getstdinfo();

        }

        // GET: api/stdinfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<stdinfo>> Getstdinfo(int id)
        {
            //var stdinfo = await _context.stdinfo.FindAsync(id);

            //if (stdinfo == null)
            //{
            //    return NotFound();
            //}

            //return stdinfo;
            try
            {
                return await _stdinfoRepository.Getstdinfo(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        //GET: api/stdinfo/5
        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<stdinfo>> GetstdinfoByPwd(string email, string password)
        {
            //var stdinfo = await _context.stdinfo.FirstOrDefaultAsync(x => x.email == email && x.password == password); ;

            //if (stdinfo == null)
            //{
            //    return NotFound();
            //}

            //return stdinfo;

            //try
            //{
            //    return await _stdinfoRepository.GetstdinfoByPwd(email, password);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex.Message);
            //    return NotFound();
            //}

            Hashtable err = new Hashtable();
            try
            {
                var authUser = await _stdinfoRepository.GetstdinfoByPwd(email, password);
                if (authUser != null)
                {
                    return Ok(authUser);
                }
                else
                {
                    err.Add("Status", "Error");

                    err.Add("Message", "Invalid Credentials");

                    return Ok(err);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }






    

        // PUT: api/stdinfoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putstdinfo(int id, stdinfo stdinfo)
        {
            if (id != stdinfo.stdid)
            {
                return BadRequest();
            }

            _context.Entry(stdinfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!stdinfoExists(id))
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

        // POST: api/stdinfoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<stdinfo>> Poststdinfo(stdinfo stdinfo)
        {
            //_context.stdinfo.Add(stdinfo);
            //await _context.SaveChangesAsync();
            await _stdinfoRepository.Poststdinfo(stdinfo);

            return CreatedAtAction("Getstdinfo", new { id = stdinfo.stdid }, stdinfo);
        }

        // DELETE: api/stdinfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<stdinfo>> Deletestdinfo(int id)
        {
            //var stdinfo = await _context.stdinfo.FindAsync(id);
            //if (stdinfo == null)
            //{
            //    return NotFound();
            //}

            //_context.stdinfo.Remove(stdinfo);
            //await _context.SaveChangesAsync();

            //return stdinfo;
            try
            {
                return await _stdinfoRepository.Deletestdinfo(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        private bool stdinfoExists(int id)
        {
            return _context.stdinfo.Any(e => e.stdid == id);
        }
    }
}

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using hellosas.Controllers.Models;
using hellosas.Data;
using System.Linq;
using hellosas.Repository;


namespace hellosas.Repository
{
    public class stdinfoRepository : IstdinfoRepository
    {
        private readonly hellosasContext _context;
        private readonly ILogger<stdinfoRepository> _logger;

        public stdinfoRepository(hellosasContext context, ILogger<stdinfoRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<ActionResult<IEnumerable<stdinfo>>> Getstdinfo()
        {
            _logger.LogInformation("Getting all the users sucessfully");
            return await _context.stdinfo.ToListAsync();
        }

        public async Task<ActionResult<stdinfo>> Getstdinfo(int id)
        {
            var stdinfo = await _context.stdinfo.FindAsync(id);
            if (stdinfo == null)
            {
                throw new NullReferenceException("sorry, no user found with this id " + id);
            }
            else
            {
                return stdinfo;
            }
        }
        public async Task<ActionResult<stdinfo>> GetstdinfoByPwd(string email, string password)
        {
            var user = await _context.stdinfo.FirstOrDefaultAsync(x => x.email== email && x.password == password);   
            if(user == null)
            {
                throw new NullReferenceException("sorry no user found with this credentials");
            }
            else
            {
                return user;
            }
        }
        public async Task<ActionResult<stdinfo>> Poststdinfo(stdinfo stdinfo)
        {
            _context.stdinfo.Add(stdinfo);
            await _context.SaveChangesAsync();
            _logger.LogInformation("User created sucessfully");

            return stdinfo;
        }

        public async Task<ActionResult<stdinfo>> Deletestdinfo(int id)
        {
            var stdinfo = await _context.stdinfo.FindAsync(id);
            if(stdinfo == null)
            {
                throw new NullReferenceException("sorry, no user found with this id " + id);
            }
            else
            {
                _context.stdinfo.Remove(stdinfo);
                await _context.SaveChangesAsync();
                _logger.LogInformation("user deleted sucessfully");

                return stdinfo;
            }
        }
        public bool stdinfoExists(int id)
        {
            return _context.stdinfo.Any(e => e.stdid == id);
        }










    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Threading.Tasks;
using hellosas.Controllers.Models;


namespace hellosas.Repository
{
    public interface IstdinfoRepository
    {
        Task<ActionResult<IEnumerable<stdinfo>>> Getstdinfo();

        Task<ActionResult<stdinfo>> Getstdinfo(int id);
        Task<ActionResult<stdinfo>> GetstdinfoByPwd(string email,string password);
        Task<ActionResult<stdinfo>> Poststdinfo(stdinfo stdinfo);
        Task<ActionResult<stdinfo>> Deletestdinfo(int id);

        bool stdinfoExists(int id);

        //Task<stdinfo>GetstdinfoByIdAsync(int id);
        //Task<stdinfo>LoginAsync(string email,string password);
        //Task<IEnumerable<stdinfo>> GetUserAsync();

        //Task CreatestdinfoAsync (stdinfo stdinfo);
        //Task UpdatestdinfoAsync(stdinfo stdinfo);
        //Task DeletestdinfoAsync (stdinfo stdinfo);


    }
}

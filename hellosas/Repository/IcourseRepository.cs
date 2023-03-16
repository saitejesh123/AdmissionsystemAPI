using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Threading.Tasks;
using hellosas.Controllers.Models;

namespace hellosas.Repository
{
    public interface IcourseRepository
    {
        Task<ActionResult<IEnumerable<course>>> Getcourse();

        Task<ActionResult<course>> Getcourse(int id);
      //  Task<ActionResult<course>> GetcourseByName(string name);


        //Task<ActionResult<course>> GetstdinfoByPwd(string email, string password);
        Task<ActionResult<course>> Putcourse(int id ,string name);
        Task<ActionResult<course>> Postcourse(course course);
        Task<ActionResult<course>> Deletecourse(int id);

        bool courseExists(int id);


    }
}

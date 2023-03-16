using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Threading.Tasks;
using hellosas.Controllers.Models;

namespace hellosas.Repository
{
    public interface IadmissioninfoRepository
    {

        Task<ActionResult<IEnumerable<admissioninfo>>> Getadmissioninfo();
        Task<ActionResult<admissioninfo>> Getadmissioninfo(int id);
        //Task<ActionResult<course>> GetstdinfoByPwd(string email, string password);
        Task<ActionResult<admissioninfo>> Postadmissioninfo(admissioninfo  admissioninfo);
        Task<ActionResult<admissioninfo>> Deleteadmissioninfo(int id);

        bool admissioninfoExists(int id);

    }
}

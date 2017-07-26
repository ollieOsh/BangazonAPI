using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BangazonAPI.Controllers
{
    [Route("api/controller")]
    public class DepartmentController : Controller
    {
        //GET api/departments
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[]{}
        }
    }   //POST api/departments
        [HttpPost]
        
}
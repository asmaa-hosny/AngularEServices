using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EServicesWithAngular.Controllers
{
    public class CommonController : BaseController
    {
        [HttpGet]
        [Route("GetEmployeeData")]
        public IActionResult GetEmployeeData()
        {
            return Ok(true);

        }

    }
}

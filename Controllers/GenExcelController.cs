using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DecToRem.Models;

namespace DecToRem.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GenExcelController : ControllerBase
    {
        
        private readonly ILogger<GenExcelController> _logger;

        public GenExcelController(ILogger<GenExcelController> logger)
        {
            _logger = logger;
        }

       [HttpGet]
       public IActionResult Generate(){
       
       	return Ok(new {Status="This is the excel file."});
       }
    }
    //it.marcusmillah@gmail.com
}

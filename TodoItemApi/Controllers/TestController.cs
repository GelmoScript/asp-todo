using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoItemApi.Contexts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoItemApi.Controllers
{

    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        private CityInfoContext _context;
        public TestController(CityInfoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}

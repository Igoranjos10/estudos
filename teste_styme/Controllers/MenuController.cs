using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste_styme.Service;

namespace teste_styme.Controllers
{
    [Route("api/Menu")]
    [ApiController]
    public class MenuController : Controller
    {
        private readonly ServiceMenu _serviceMenu;

        public MenuController(ServiceMenu serviceMenu)
        {
            _serviceMenu = serviceMenu;
        }

        [HttpGet]
        public IActionResult Get(string name)
        {
            var menu = _serviceMenu.List(name);


            return Ok(menu);
        }
    }
}

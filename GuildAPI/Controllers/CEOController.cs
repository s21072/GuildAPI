using GuildAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Controllers
{
    [ApiController]
    [Route("ceo")]
    public class CEOController : Controller
    {
        private readonly ICEODBService _service;

        public CEOController(ICEODBService service)
        {
            _service = service;
        }
        //Pobieranie wszystkich ceo
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await _service.Get();
        }
        //Dodawanie ceo
        [HttpPost("create")]
        public async Task<IActionResult> CreateAdv(string pesel)
        {
            return await _service.Create(pesel);
        }
    }
}

using GuildAPI.DTOs.Requests;
using GuildAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Controllers
{
    [ApiController]
    [Route("person")]
    public class PersonController : Controller
    {
        private readonly IPersonDBService _service;

        public PersonController(IPersonDBService service)
        {
            _service = service;
        }
        //Pobieranie wszystkich ludziów
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await _service.Get();
        }

        //Pobieranie ludziów po peselu
        [HttpGet("{pesel}")]
        public async Task<IActionResult> Get(string pesel)
        {
            return await _service.Get(pesel);
        }
        //Dodawanie ludzia
        [HttpPost("create")]
        public async Task<IActionResult> CreateAdv(AddPerson create)
        {
            return await _service.Create(create);
        }
    }
}

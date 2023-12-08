using GuildAPI.DTOs.Requests;
using GuildAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureGuild.Controllers
{
    [ApiController]
    [Route("adventurers")]
    public class AdventurerController : Controller
    {
        private readonly IAdventurerDBService _service;

        public AdventurerController(IAdventurerDBService service)
        {
            _service = service;
        }
        //Pobieranie wszystkich adventurerów
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await _service.Get();
        }

        //Pobieranie adventurera po peselu
        [HttpGet("{pesel}")]
        public async Task<IActionResult> Get(string pesel)
        {
            return await _service.Get(pesel);
        }
        //Pobieranie adventurera po peselu
        [HttpGet("getFree")]
        public async Task<IActionResult> GetFree()
        {
            return await _service.GetFree();
        }
        //Zmiana statusu
        [HttpPost("changeStatus")]
        public async Task<IActionResult> SetStatuses(ChangeAdvStatus status)
        {
            return await _service.ChangeStatuses(status);
        }
        //Dodawanie adventurera
        [HttpPost("create")]
        public async Task<IActionResult> CreateAdv(CreateAdv create)
        {
            return await _service.CreateAdventurer(create);
        }
    }
}

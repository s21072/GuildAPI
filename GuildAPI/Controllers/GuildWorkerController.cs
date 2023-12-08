using GuildAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureGuild.Controllers
{
    [ApiController]
    [Route("guildWorkers")]
    public class GuildWorkerController : Controller
    {
        private readonly IGuildWorkerDBService _service;

        public GuildWorkerController(IGuildWorkerDBService service)
        {
            _service = service;
        }
        //Pobieranie wszystkich gw
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await _service.Get();
        }

        //Pobieranie gw po peselu
        [HttpGet("{pesel}")]
        public async Task<IActionResult> Get(string pesel)
        {
            return await _service.Get(pesel);
        }
        //Pobieranie terrain workerów
        [HttpGet("terrainWorkers")]
        public async Task<IActionResult> GetTW()
        {
            return await _service.GetTerrainWorkers();
        }
        //Dodawanie adventurera
        [HttpPost("create")]
        public async Task<IActionResult> CreateGW(string pesel)
        {
            return await _service.CreateGuildWorker(pesel);
        }
        //Zmiana typu gw
        [HttpPost("changeType/{pesel}")]
        public async Task<IActionResult> ChangeType(string pesel)
        {
            await _service.CountBonus(pesel);
            return await _service.ChangeType(pesel);
        }
        //Zmiana typu gw
        [HttpPost("bonus/{pesel}")]
        public async Task<IActionResult> CountBonus(string pesel)
        {
            return await _service.CountBonus(pesel);
        }
    }
}

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
    [Route("commission")]
    public class CommissionController : Controller
    {
        private readonly ICommissionDBService _service;

        public CommissionController(ICommissionDBService service)
        {
            _service = service;
        }
        //Pobieranie wszystkich zleceń
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await _service.Get();
        }

        //Pobieranie zlecenia po id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return await _service.Get(id);
        }
        //ustalenie eC
        [HttpPost("emergencyCommission")]
        public async Task<IActionResult> SetStatuses(EmergencyCommission emergencyCommission)
        {
            string pesel = "444444";
            return await _service.CreateEmergency(emergencyCommission, pesel);
        }
    }
}

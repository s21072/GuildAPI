using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildAPI.DTOs.Requests;
using GuildAPI.Services.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace GuildAPI.Controllers
{
    [ApiController]
    [Route("address")]
    public class AddressController : Controller
    {
        private readonly IAddressDBService _service;

        public AddressController(IAddressDBService service)
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
        //dodawanie adresu
        [HttpPost("create")]
        public async Task<IActionResult> Create(AddAddress create)
        {
            return await _service.Create(create);
        }
    }
}

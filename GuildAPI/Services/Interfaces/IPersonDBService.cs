using GuildAPI.DTOs.Requests;
using GuildAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Services.Interfaces
{
    public interface IPersonDBService
    {
        public Task<IActionResult> Get();
        public Task<IActionResult> Get(string pesel);
        public Task<IActionResult> Create(AddPerson person);
    }
}

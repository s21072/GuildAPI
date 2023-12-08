using GuildAPI.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Services.Interfaces
{
    public interface IAddressDBService
    {
        public Task<IActionResult> Get();
        public Task<IActionResult> Get(int id);
        public Task<IActionResult> Create(AddAddress address);
    }
}

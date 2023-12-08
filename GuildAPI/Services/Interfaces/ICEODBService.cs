using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Services.Interfaces
{
    public interface ICEODBService
    {
        public Task<IActionResult> Get();
        public Task<IActionResult> Create(string pesel);
    }
}

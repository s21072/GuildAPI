using GuildAPI.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Services.Interfaces
{
    public interface IGuildWorkerDBService
    {
        public Task<IActionResult> Get();
        public Task<IActionResult> Get(string pesel);
        public Task<IActionResult> GetTerrainWorkers();
        public Task<IActionResult> ChangeType(string pesel);
        public Task<IActionResult> CountBonus(string pesel);
        public Task<IActionResult> CreateGuildWorker(string pesel);
    }
}

using GuildAPI.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Services.Interfaces
{
    public interface ITeamDBService
    {
        public Task<IActionResult> Get();
        public Task<IActionResult> Get(int id);
        public Task<IActionResult> CreateTeam();
        public Task<IActionResult> AddAdventurerToTeam(int teamID, string pesel);
        public Task<IActionResult> AddGuildWorkerToTeam(int teamID, string pesel);
    }
}

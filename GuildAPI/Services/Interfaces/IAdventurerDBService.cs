using GuildAPI.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Services.Interfaces
{
    public interface IAdventurerDBService
    {
        public Task<IActionResult> Get();
        public Task<IActionResult> Get(string pesel);
        public Task<IActionResult> GetFree();
        public Task<IActionResult> SetCommission(string pesel, int commID);
        public Task<IActionResult> SetTeam(string pesel, int teamID);
        public Task<IActionResult> ChangeStatuses(ChangeAdvStatus status);
        public Task<IActionResult> CreateAdventurer(CreateAdv createAdv);
    }
}

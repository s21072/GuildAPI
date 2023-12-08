using GuildAPI.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Services.Interfaces
{
    public interface ICommissionDBService
    {
        public Task<IActionResult> Get();
        public Task<IActionResult> Get(int id);
        public Task<IActionResult> CreateEmergency(EmergencyCommission emergencyCommission, string creator);
    }
}

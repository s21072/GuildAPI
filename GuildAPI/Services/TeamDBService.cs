using GuildAPI.Models;
using GuildAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Services
{
    public class TeamDBService : ITeamDBService
    {
        private readonly MyDBContext _context;

        public TeamDBService(MyDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AddAdventurerToTeam(int teamID, string pesel)
        {
            var adventurer = await _context.Adventurers.FirstOrDefaultAsync(o => o.Pesel == pesel);
            var team = await _context.Teams.FirstOrDefaultAsync(o => o.TeamID == teamID);

            if (adventurer == null || team == null) return new NotFoundResult(); //Walidacja czy istnieje
            if (!team.Adventurers.Contains(adventurer)) team.Adventurers.Add(adventurer);

            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<IActionResult> AddGuildWorkerToTeam(int teamID, string pesel)
        {
            var guildWorker = await _context.GuildWorkers.FirstOrDefaultAsync(o => o.Pesel == pesel);
            var team = await _context.Teams.FirstOrDefaultAsync(o => o.TeamID == teamID);

            if (guildWorker == null || team == null) return new NotFoundResult(); //Walidacja czy istnieje
            if(guildWorker.WorkRole != WorkRole.TerrainWorker) return new BadRequestResult();
            if (!team.GuildWorker.Contains(guildWorker) && team.GuildWorker.Count < 3) team.GuildWorker.Add(guildWorker);
            else return new BadRequestResult();

            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<IActionResult> CreateTeam()
        {
            int teamID = 1;
            if (await _context.Teams.AnyAsync()) teamID = await _context.Teams.MaxAsync(p => p.TeamID) + 1;
            var team = new Team()
            {
                TeamID = teamID
            };
            await _context.AddAsync(team);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(await _context.Teams.ToListAsync());
        }

        public async Task<IActionResult> Get(int id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(o => o.TeamID == id);

            if (team == null) return new NotFoundResult();

            return new OkObjectResult(team);
        }
    }
}

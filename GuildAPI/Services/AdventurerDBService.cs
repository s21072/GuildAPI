using GuildAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GuildAPI.Models;
using GuildAPI.DTOs.Requests;

namespace GuildAPI.Services
{
    public class AdventurerDBService : IAdventurerDBService
    {
        private readonly MyDBContext _context;

        public AdventurerDBService(MyDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ChangeStatuses(ChangeAdvStatus status)
        {
            var adventurer = await _context.Adventurers.FirstOrDefaultAsync(o => o.Pesel == status.Pesel);
            adventurer.CommissionID = status.CommissionID;
            adventurer.Commission = await _context.Commissions.FirstOrDefaultAsync(o => o.CommissionID == status.CommissionID);
            adventurer.TeamID = status.TeamID;
            adventurer.Team = await _context.Teams.FirstOrDefaultAsync(o => o.TeamID == status.TeamID);

            await _context.SaveChangesAsync();
            return new OkResult();
        }

        public async Task<IActionResult> CreateAdventurer(CreateAdv createAdv)
        {
            if (await _context.Adventurers.AnyAsync(p => p.Pesel == createAdv.Pesel)) return new BadRequestResult();
            var person = await _context.Person.FirstOrDefaultAsync(o => o.Pesel == createAdv.Pesel);
            if(person == null) return new NotFoundResult();
            if(DateTime.Now.Year - person.Birth.Year < Adventurers.age) return new BadRequestResult();
            var adv = new Adventurers()
            {
                Pesel = createAdv.Pesel,
                Person = await _context.Person.FirstOrDefaultAsync(o => o.Pesel == createAdv.Pesel),
                Str = createAdv.Str,
                Spd = createAdv.Spd,
                Vit = createAdv.Vit,
                Int = createAdv.Int
            };
            await _context.AddAsync(adv);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(await _context.Adventurers.ToListAsync());
        }

        public async Task<IActionResult> Get(string pesel)
        {
            var adventurer = await _context.Adventurers.FirstOrDefaultAsync(o => o.Pesel == pesel);

            if (adventurer == null) return new NotFoundResult();

            return new OkObjectResult(adventurer);
        }

        public async Task<IActionResult> GetFree()
        {
            return new OkObjectResult(await _context.Adventurers.Where(p=> p.CommissionID == null).ToListAsync());
        }

        public async Task<IActionResult> SetCommission(string pesel, int commID)
        {
            var adventurer = await _context.Adventurers.FirstOrDefaultAsync(o => o.Pesel == pesel);
            adventurer.CommissionID = commID;
            adventurer.Commission = await _context.Commissions.FirstOrDefaultAsync(o => o.CommissionID == commID);

            await _context.SaveChangesAsync();
            return new OkResult();
        }

        public async Task<IActionResult> SetTeam(string pesel, int teamID)
        {
            var adventurer = await _context.Adventurers.FirstOrDefaultAsync(o => o.Pesel == pesel);
            adventurer.TeamID = teamID;
            adventurer.Team = await _context.Teams.FirstOrDefaultAsync(o => o.TeamID == teamID);

            await _context.SaveChangesAsync();
            return new OkResult();
        }
    }
}

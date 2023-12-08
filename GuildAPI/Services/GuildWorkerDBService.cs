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
    public class GuildWorkerDBService : IGuildWorkerDBService
    {
        private readonly MyDBContext _context;

        public GuildWorkerDBService(MyDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ChangeType(string pesel)
        {
            var gw = await _context.GuildWorkers.FirstOrDefaultAsync(o => o.Pesel == pesel);
            if (gw.WorkRole == WorkRole.InsideWorker) gw.WorkRole = WorkRole.TerrainWorker;
            else gw.WorkRole = WorkRole.InsideWorker;

            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<IActionResult> CountBonus(string pesel)
        {
            var gw = await _context.GuildWorkers.FirstOrDefaultAsync(o => o.Pesel == pesel);
            if (gw.WorkRole == WorkRole.InsideWorker) return new OkResult();
            else gw.Bonus = gw.NymberOfCommissionsDone * 250;

            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<IActionResult> CreateGuildWorker(string pesel)
        {
            if (await _context.GuildWorkers.AnyAsync(p => p.Pesel == pesel)) return new BadRequestResult();
            var person = await _context.Person.FirstOrDefaultAsync(o => o.Pesel == pesel);
            if (person == null) return new NotFoundResult();
            var gw = new GuildWorker() {
                Pesel = pesel,
                Person = person,
                Salary = 4500,
                WorkRole = WorkRole.InsideWorker,
                Bonus = 0,
                NymberOfCommissionsDone = 0
            };
            await _context.AddAsync(gw);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(await _context.GuildWorkers.ToListAsync());
        }

        public async Task<IActionResult> Get(string pesel)
        {
            var gw = await _context.GuildWorkers.FirstOrDefaultAsync(o => o.Pesel == pesel);

            if (gw == null) return new NotFoundResult();

            return new OkObjectResult(gw);
        }

        public async Task<IActionResult> GetTerrainWorkers()
        {
            return new OkObjectResult(await _context.GuildWorkers.Where(p => p.WorkRole == WorkRole.TerrainWorker).ToListAsync());
        }
    }
}

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
    public class CEODBService : ICEODBService
    {
        private readonly MyDBContext _context;

        public CEODBService(MyDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create(string pesel)
        {
            if (await _context.CEOs.AnyAsync(p => p.Pesel == pesel)) return new BadRequestResult();
            var pp = await _context.Person.FirstOrDefaultAsync(o => o.Pesel == pesel);
            if (pp == null) return new NotFoundResult();
            var tmp = new CEO()
            {
                Pesel = pesel,
                Person = pp
            };
            await _context.AddAsync(tmp);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(await _context.CEOs.ToListAsync());
        }

    }
}

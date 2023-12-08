using GuildAPI.DTOs.Requests;
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
    public class PersonDBService : IPersonDBService
    {
        private readonly MyDBContext _context;

        public PersonDBService(MyDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create(AddPerson person)
        {
            if (await _context.Person.AnyAsync(p => p.Pesel == person.Pesel)) return new BadRequestResult();
            var address = await _context.Addresses.FirstOrDefaultAsync(o => o.AddressId == person.AddressId);
            if (address == null) return new NotFoundResult();
            var pp = new Person()
            {
                Pesel = person.Pesel,
                AddressId = person.AddressId,
                Address = address,
                Name = person.Name,
                Surname = person.Surname,
                Birth = person.Birth,
                PhoneNumber = person.PhoneNumber,
                IsAdventurer = false,
                Start = DateTime.Now
            };
            await _context.AddAsync(pp);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(await _context.Person.ToListAsync());
        }

        public async Task<IActionResult> Get(string pesel)
        {
            var person = await _context.Person.FirstOrDefaultAsync(o => o.Pesel == pesel);

            if (person == null) return new NotFoundResult();

            return new OkObjectResult(person);
        }
    }
}

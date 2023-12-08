using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildAPI.DTOs.Requests;
using GuildAPI.Models;
using GuildAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuildAPI.Services
{
    public class AddressDBService : IAddressDBService
    {
        private readonly MyDBContext _context;

        public AddressDBService(MyDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create(AddAddress address)
        {
            int idAddress = 1;
            var tmp = await _context.Addresses
                .FirstOrDefaultAsync(o => 
                o.City == address.City && o.Street == address.Street && o.Number == address.Number && o.Post == address.Post);
            if (tmp != null) return new BadRequestResult();
            if (await _context.Addresses.AnyAsync()) idAddress = await _context.Addresses.MaxAsync(p => p.AddressId) + 1;
            tmp = new Address() { 
                //AddressId = idAddress,
                City = address.City,
                Street = address.Street,
                Number = address.Number,
                Post = address.Post
            };
            await _context.AddAsync(tmp);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(await _context.Addresses.ToListAsync());
        }

        public async Task<IActionResult> Get(int id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(o => o.AddressId == id);

            if (address == null) return new NotFoundResult();

            return new OkObjectResult(address);
        }
    }
}

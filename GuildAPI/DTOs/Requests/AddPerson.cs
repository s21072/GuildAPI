using GuildAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.DTOs.Requests
{
    public class AddPerson
    {
        public string Pesel { get; set; }
        public int AddressId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birth { get; set; }
        public string PhoneNumber { get; set; }
    }
}

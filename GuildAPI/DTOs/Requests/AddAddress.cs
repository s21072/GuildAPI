using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.DTOs.Requests
{
    public class AddAddress
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Post { get; set; }
    }
}

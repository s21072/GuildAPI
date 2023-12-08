using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.DTOs.Requests
{
    public class CreateAdv
    {
        public string Pesel { get; set; }
        public int Str { get; set; }
        public int Int { get; set; }
        public int Vit { get; set; }
        public int Spd { get; set; }
    }
}

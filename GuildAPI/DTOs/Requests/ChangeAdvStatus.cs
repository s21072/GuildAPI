using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.DTOs.Requests
{
    public class ChangeAdvStatus
    {
        public string Pesel { get; set; }
        public int TeamID { get; set; }
        public int CommissionID { get; set; }
    }
}

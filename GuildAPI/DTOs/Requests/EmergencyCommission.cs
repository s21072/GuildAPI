using GuildAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.DTOs.Requests
{
    public class EmergencyCommission
    {
        public string Title { get; set; }
        public string MinRank { get; set; }
        public string Description { get; set; }
        public string[] GuildWorkers { get; set; }
        public string[] Adventurers { get; set; }
    }
}

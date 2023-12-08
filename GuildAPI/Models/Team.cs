using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models
{
    public class Team
    {
        public int TeamID { get; set; }

        public ICollection<Adventurers> Adventurers = new List<Adventurers>();
        public ICollection<GuildWorker> GuildWorker = new List<GuildWorker>();
    }
}

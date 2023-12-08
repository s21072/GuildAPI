using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models
{
    public class Lend
    {
        public int LendID { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int HowMuch { get; set; }
        public int EquipmentID { get; set; }
        public Equipment Equipment { get; set; }
        public string Pesel { get; set; }
        public Person Person { get; set; }
        public int TrainingID { get; set; }
        public Training Training { get; set; } 

    }
}

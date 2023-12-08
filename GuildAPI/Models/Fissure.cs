using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models
{
    public class Fissure
    {
        public int FissureID { get; set; }
        public float NSLoc { get; set; }
        public float WELoc { get; set; }
        public float OSLev { get; set; }
        [EnumDataType(typeof(Ranks), ErrorMessage = "This rank does not exist!")]
        public Ranks? Rank { get; set; }
        [EnumDataType(typeof(FissureTypes), ErrorMessage = "This rank does not exist!")]
        public FissureTypes FissureTypes { get; set; }
        public DateTime FindDate { get; set; }
        public ICollection<Country> Country { get; set; }
        public DateTime? CloseDate { get; set; }
        public ICollection<Commission> Commission { get; set; }

    }
}

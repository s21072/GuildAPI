using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models
{
    public abstract class Equipment
    {
        public int EquipmentID { get; set; }
        public string Name { get; set; }
        [EnumDataType(typeof(Ranks), ErrorMessage = "This rank does not exist!")]
        public Ranks Rank { get; set; }
    }
}

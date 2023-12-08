using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models
{
    public class Commission
    {
        public int CommissionID { get; set; }
        public string Title { get; set; }
        [EnumDataType(typeof(CommissionTypes), ErrorMessage = "This type does not exist!")]
        public CommissionTypes CommissionType { get; set; }
        [EnumDataType(typeof(Ranks), ErrorMessage = "This rank does not exist!")]
        public Ranks MinRank { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? AcceptTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public float Reword { get; set; }
        public int Rates { get; set; }
        public string Description { get; set; }
        public string Pesel { get; set; }
        public Person Person { get; set; }
#nullable enable
        public int? FissureID { get; set; }
        public Fissure? Fissure { get; set; }
#nullable disable
        public int TeamID { get; set; }
        public Team Team { get; set; }
    }
}

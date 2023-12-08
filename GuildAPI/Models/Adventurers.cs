using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models
{
    public class Adventurers
    {
        public static int age = 17;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Pesel { get; set; }
        public Person Person { get; set; }
        public int Str { get; set; }
        public int Int { get; set; }
        public int Vit { get; set; }
        public int Spd { get; set; }
        public int MinAge { get => age; }
#nullable enable
        public int? CommissionID { get; set; }
        public Commission? Commission { get; set; }
        public int? TeamID { get; set; }
        public Team? Team { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models
{
    public class GuildWorker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Pesel { get; set; }
        public Person Person { get; set; }
        public int Salary { get; set; }
        [EnumDataType(typeof(WorkRole), ErrorMessage = "This rank does not exist!")]
        public WorkRole WorkRole { get; set; }
        public float? Bonus { get; set; }
        public int NymberOfCommissionsDone { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models
{
    public class Training
    {
        public int TrainingID { get; set; }
        public string Theme { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [EnumDataType(typeof(Attributes), ErrorMessage = "This attribute does not exist!")]
        public Attributes Attribute { get; set; }
        public int TeamID { get; set; }
        public Team Team { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Pesel { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birth { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdventurer { get; set; }
        [EnumDataType(typeof(Ranks), ErrorMessage = "This rank does not exist!")]
        public Ranks? Rank { get; set; }
        public DateTime Start { get; set; }
        public DateTime? Retirement { get; set; }
    }
}

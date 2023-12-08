using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models
{
    public class CEO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Pesel { get; set; }
        public Person Person { get; set; }
    }
}

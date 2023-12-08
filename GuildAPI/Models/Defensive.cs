using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildAPI.Models
{
    public class Defensive : Equipment, IDefensive
    {
        public int Def { get ; set ; }
    }
}

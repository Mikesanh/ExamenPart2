using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenPart2.API.Models
{
    public class SongDto
    {   
        public int sid { get; set; }
        public bool bought { get; set; }
        public string songName { get; set; }
        public string artistName { get; set; }
        public int duration { get; set; }
        public int popularity { get; set; }
        public double price { get; set; }

    }
}

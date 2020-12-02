using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenPart2.Core.Entities
{
    public class Song : BaseEntity
    {
        public int albumId { get; set; }
        public int sid { get; set; }
        public bool bought { get; set; }
        public string songName { get; set; }
        public string artistName { get; set; }
        public int duration { get; set; }
        public int popularity { get; set; }
        public double price { get; set; }

    }
}

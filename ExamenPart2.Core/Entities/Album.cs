using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenPart2.Core.Entities
{
    public class Album : BaseEntity
    {
        public int id { get; set; }
        public bool bought { get; set; }
        public string albumName { get; set; }
        public string artistName { get; set; }
        public double price { get; set; }
        public string genre { get; set; }
        public int score { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public ICollection<Song> songs { get; set; }


    }
}

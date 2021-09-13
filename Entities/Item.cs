using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chicken.Entities
{
    public class Item
    {
        public string Partition { get; set; }
        public string id { get; set; }
        public string entryTimeUtc { get; set; }
        public string timezone { get; set; }
        public int trackId { get; set; }
        public bool hasMinorLesion { get; set; }
        public bool hasMediumLesion { get; set; }
        public bool hasMajorLesion { get; set; }
    }
}

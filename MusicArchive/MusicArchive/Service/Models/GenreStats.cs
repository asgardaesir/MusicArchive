using System.Collections.Generic;

namespace MusicArchive.Models
{
    public class BandStatAggregation
    {
        public List<string> Genres { get; set; }
        public List<int> Counts { get; set; }
    }
}
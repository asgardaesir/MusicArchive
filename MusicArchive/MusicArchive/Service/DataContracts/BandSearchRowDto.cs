using System;

namespace MusicArchive.Controllers
{
    public class BandSearchRowDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CountryOfOrgin { get; set; }
        public string Genre { get; set; }
        public string Status { get; set; }
        public string BandImage { get; set; }
    }
}
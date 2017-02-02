using System;
using System.Collections.Generic;
using MusicArchive.Models;
using MusicArchive.Repositories;

namespace MusicArchive
{
    public class BandDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CountryOfOrgin { get; set; }
        public string Location { get; set; }
        public string FormedIn { get; set; }
        public string YearsActive { get; set; }
        public string Genre { get; set; }
        public Label CurrentLabel { get; set; }
        public string LyricalThemes { get; set; }
        public List<Artist> Members { get; set; }
        public List<BandAlbumDto> Albums { get; set; }

        public string BandLogo { get; set; }
        public string BandImage { get; set; }
    }
}
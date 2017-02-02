using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicArchive.Models
{
    public class Band
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CountryOfOrgin { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string FormedIn { get; set; }
        public string YearsActive { get; set; }
        public string Genre { get; set; }
        public Label CurrentLabel { get; set; }
        public string LyricalThemes { get; set; }
        public byte[] BandLogo { get; set; }
        public byte[] BandImage { get; set; }
        public IEnumerable<string> Tags { get; set; } 
        public virtual ICollection<Artist> Members { get; set; }
        public virtual ICollection<Album> Albums { get; set; } 
    }
}
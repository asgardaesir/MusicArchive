using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicArchive.Models
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Label Label { get; set; }
        public string Type { get; set; }
        public string ReleaseDate { get; set; }
        public string Rating { get; set; }
        public Guid BandId { get; set; }
        public virtual Band AlbumArtist { get; set; }
        public string CatalogId { get; set; }
        public string Format { get; set; }
        public byte[] Cover { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
        public virtual ICollection<Review> Reviews { get; set; } 
    }
}
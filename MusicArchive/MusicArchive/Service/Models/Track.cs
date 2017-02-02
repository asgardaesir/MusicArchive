using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicArchive.Models
{
    public class Track
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int TrackNumber { get; set; }
        public string Name { get; set; }
        public string Lyrics { get; set; }
        public Guid AlbumId { get; set; }
        public virtual Album Album { get; set; }
    }
}
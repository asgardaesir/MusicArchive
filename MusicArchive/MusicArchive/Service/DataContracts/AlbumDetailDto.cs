using System;
using System.Collections.Generic;

namespace MusicArchive.Controllers
{
    public class AlbumDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string BandName { get; set; }
        public string Type { get; set; }
        public string ReleaseDate { get; set; }
        public string CatalogId { get; set; }
        public string Label { get; set; }
        public string Format { get; set; }
        public string AlbumArt { get; set; }
        public List<TrackDto> Tracks { get; set; } 
        public List<ReviewDto> Reviews { get; set; } 
        public int ReviewAverage { get; set; }
    }

    public class TrackDto
    {
        public int TrackNumber { get; set; }
        public string Name { get; set; }
        public string Lyrics { get; set; }
    }

    public class ReviewDto
    {
        public Guid Id { get; set; }
        public string ReviewText { get; set; }
        public float Rating { get; set; }
    }
}
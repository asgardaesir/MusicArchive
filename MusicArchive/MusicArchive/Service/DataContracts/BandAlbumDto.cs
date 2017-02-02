using System;
using MusicArchive.Models;

namespace MusicArchive
{
    public class BandAlbumDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Label Label { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }
        public string Rating { get; set; }

        public string Cover { get; set; }
    }
}
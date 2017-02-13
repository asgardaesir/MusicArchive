using System;
using System.Collections.Generic;

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

    public class BandSearchResultsDto
    {
        public BandSearchResultsDto(int results, List<BandSearchRowDto> searchResults)
        {
            Results = results;
            SearchResults = searchResults;
        }

        public int Results { get; set; }

        public int CurrentPage { get; set; }

        public List<BandSearchRowDto> SearchResults { get; set; } 
    }
}
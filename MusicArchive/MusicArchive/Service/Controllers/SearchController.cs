using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using MusicArchive.Models;
using MusicArchive.Repositories;

namespace MusicArchive.Controllers
{
    public class SearchController : ApiController
    {
        private readonly ISearchRepository _searchRepository;

        public SearchController(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }

        [HttpGet]
        public IEnumerable<BandSearchRowDto> Search([FromUri]string bandName, [FromUri]string countryOfOrigin, [FromUri]string label, [FromUri]string lyricalThemes, [FromUri]string genre, [FromUri]string yearOfFormation)
        {
                var results = _searchRepository.Search(new BandSearchInformation
                {
                    BandName = bandName,
                    CountryOfOrigin = countryOfOrigin,
                    Label = label,
                    Genre = genre,
                    LyricalThemes = lyricalThemes,
                    YearOfFormation = yearOfFormation
                });

            return results.ToList().Select(Mapper.Map<Band, BandSearchRowDto>);
        }
    }
}
using System.Collections.Generic;
using MusicArchive.Models;

namespace MusicArchive
{
    public interface ISearchRepository
    {
        IEnumerable<Band> Search(BandSearchInformation bandSearchInformation, out int totalMatches);
    }
}
using System.Collections.Generic;
using MusicArchive.Controllers;
using MusicArchive.Models;

namespace MusicArchive.Repositories
{
    public interface ISearchRepository
    {
        IEnumerable<Band> Search(BandSearchInformation bandSearchInformation);
    }
}
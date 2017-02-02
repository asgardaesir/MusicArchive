using System;
using MusicArchive.Controllers;

namespace MusicArchive
{
    public interface IAlbumRepository
    {
        AlbumDetailDto GetAlbum(Guid id);
        void Review(ReviewDto review);
    }
}
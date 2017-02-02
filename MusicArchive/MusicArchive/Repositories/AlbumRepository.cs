using System;
using System.Linq;
using AutoMapper;
using MusicArchive.Models;

namespace MusicArchive.Controllers
{
    public class AlbumRepository : IAlbumRepository
    {
        public AlbumDetailDto GetAlbum(Guid id)
        {
            using (var context = new MusicArchiveContext())
            {
                var matchingAlbum = context.Albums
                    .Include("Reviews")
                    .Include("Tracks")
                    .Single(album => album.Id == id);

                var albumDto = Mapper.Map<Album, AlbumDetailDto>(matchingAlbum);
                albumDto.ReviewAverage = albumDto.Reviews.Count > 0 ? (int)albumDto.Reviews.Average(dto => dto.Rating) : 0;

                return albumDto;
            }
        }

        public void Review(ReviewDto review)
        {
            using (var context = new MusicArchiveContext())
            {
                var album = context.Albums.Single(a => a.Id == review.Id);

                var newReview = new Review
                {
                    Rating = review.Rating,
                    ReviewText = review.ReviewText
                };

                album.Reviews.Add(newReview);
                context.SaveChanges();
            }
        }
    }
}
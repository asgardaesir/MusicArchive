using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicArchive.Controllers
{
    [RoutePrefix("api/album")]
    public class AlbumController : ApiController
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumController(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public AlbumDetailDto GetAlbum(Guid id)
        {
            var album = _albumRepository.GetAlbum(id);
            return album;
        }

        [HttpPost]
        public HttpResponseMessage Review(ReviewDto review)
        {
            _albumRepository.Review(review);
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }
    }
}

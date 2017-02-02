using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using MusicArchive.Models;

namespace MusicArchive.Controllers
{
    [RoutePrefix("api/band")]
    public class BandController : ApiController
    {
        private readonly IBandRepository _bandRepository;

        public BandController(IBandRepository bandRepository)
        {
            _bandRepository = bandRepository;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public BandDetailDto GetBand(Guid id)
        {
            var band = _bandRepository.GetBandById(id);
            var result = Mapper.Map<Band, BandDetailDto>(band);
            return result;
        }

        [HttpPost]
        [Authorize]
        [Route("")]
        public HttpResponseMessage Post(NewBandBindingModel newBand)
        {
            _bandRepository.AddBand(newBand);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

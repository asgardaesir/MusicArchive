using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MusicArchive.Models;

namespace MusicArchive.Controllers
{
    public class StatsController : ApiController
    {
        private readonly IBandRepository _bandRepository;

        public StatsController(IBandRepository bandRepository)
        {
            _bandRepository = bandRepository;
        }

        [HttpGet]
        [Route("api/stats")]
        public HttpResponseMessage GetStats()
        {
            using (var context = new MusicArchiveContext())
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var bandCount = context.Bands.Count();
                var albumCount = context.Albums.Count();
                stopwatch.Stop();

                var statsMessage = string.Format("{0} bands, {1} albums on site. {2} milliseconds to retrive stats",
                    bandCount, albumCount, stopwatch.ElapsedMilliseconds);

                return Request.CreateResponse(HttpStatusCode.OK, new {content = statsMessage });
            }
        }

        public BandStatAggregation GetByGenre()
        {
            return _bandRepository.GetBandStatsByGenre();
        }

        public BandStatAggregation GetByCountry()
        {
            return _bandRepository.GetBandStatsByCountry();
        }

        public BandStatAggregation GetByStatus()
        {
            return _bandRepository.GetBandStatsByStatus();
        }
    }
}

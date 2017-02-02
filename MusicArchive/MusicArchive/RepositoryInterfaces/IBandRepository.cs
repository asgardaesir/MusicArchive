using System;
using MusicArchive.Models;

namespace MusicArchive
{
    public interface IBandRepository
    {
        Band GetBandById(Guid bandId);

        void AddBand(NewBandBindingModel bindingModel);

        BandStatAggregation GetBandStatsByStatus();

        BandStatAggregation GetBandStatsByGenre();

        BandStatAggregation GetBandStatsByCountry();
    }
}
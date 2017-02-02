using System;
using System.Collections.Generic;
using System.Linq;
using MusicArchive.Models;

namespace MusicArchive.Repositories
{
    public class BandRepository : IBandRepository
    {
        public Band GetBandById(Guid bandId)
        {
            using (var context = new MusicArchiveContext())
            {
                return context.Bands
                    .Include("Albums")
                    .Include("Members").Single(band => band.Id == bandId);
            }
        }

        public void AddBand(NewBandBindingModel newBand)
        {
            using (var context = new MusicArchiveContext())
            {
                var band = new Band
                {
                    Name = newBand.Name,
                    CountryOfOrgin = newBand.CountryOfOrigin,
                    Genre = newBand.Genre,
                    FormedIn = newBand.YearOfFormation,
                    LyricalThemes = JoinTags(newBand.LyricalThemes)
                };

                context.Bands.Add(band);
                context.SaveChanges();
            }
        }

        public BandStatAggregation GetBandStatsByStatus()
        {
            return GetBandsBy(context => context.Bands.GroupBy(band => band.Status));
        }

        public BandStatAggregation GetBandStatsByGenre()
        {
            return GetBandsBy(context => context.Bands.GroupBy(band => band.Genre));
        }

        public BandStatAggregation GetBandStatsByCountry()
        {
            return GetBandsBy(context => context.Bands.GroupBy(band => band.CountryOfOrgin));
        }

        private BandStatAggregation GetBandsBy(Func<MusicArchiveContext, IQueryable<IGrouping<string, Band>>> source)
        {
            using (var context = new MusicArchiveContext())
            {
                var genreStats = new BandStatAggregation();

                Dictionary<string, int> genreCounts = new Dictionary<string, int>();

                foreach (IGrouping<string, Band> genre in source(context))
                {
                    if (genre.Key == null)
                    {
                        if (genreCounts.ContainsKey(string.Empty))
                        {
                            genreCounts[string.Empty] += genre.Count();
                        }
                        else
                        {
                            genreCounts.Add(string.Empty, genre.Count());
                        }
                    }
                    else if (genreCounts.ContainsKey(genre.Key))
                    {
                        genreCounts[genre.Key] += genre.Count();
                    }
                    else
                    {
                        genreCounts.Add(genre.Key, genre.Count());
                    }

                    genreStats.Genres = genreCounts.Keys.ToList();
                    genreStats.Counts = genreCounts.Values.ToList();
                }

                return genreStats;
            }
        }

        private string JoinTags(TagBindingModel[] lyricalThemeTags)
        {
            if (lyricalThemeTags == null || !lyricalThemeTags.Any())
            {
                return string.Empty;
            }

            return string.Join(",", lyricalThemeTags.Select(model => model.Text));
        }
    }
}
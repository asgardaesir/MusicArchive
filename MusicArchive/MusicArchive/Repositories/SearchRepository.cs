using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MusicArchive.Models;

namespace MusicArchive.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        public IEnumerable<Band> Search(BandSearchInformation bandSearchInformation)
        {
            using (var context = new MusicArchiveContext())
            {
                IQueryable<Band> matches= new EnumerableQuery<Band>(context.Bands);

                if (!string.IsNullOrWhiteSpace(bandSearchInformation.BandName))
                {
                    matches = matches.Where(b => b.Name.Contains(bandSearchInformation.BandName));
                }

                if (!string.IsNullOrWhiteSpace(bandSearchInformation.CountryOfOrigin))
                {
                    matches = matches.Where(band1 => band1.CountryOfOrgin == bandSearchInformation.CountryOfOrigin);
                }

                if (!string.IsNullOrWhiteSpace(bandSearchInformation.Genre))
                {
                    matches = matches.Where(band1 => band1.Genre == bandSearchInformation.Genre);
                }

                if (!string.IsNullOrWhiteSpace(bandSearchInformation.Label))
                {
                    //matches = matches.Where(band1 => band1.CurrentLabel == bandSearchInformation.Label);
                }

                if (!string.IsNullOrWhiteSpace(bandSearchInformation.YearOfFormation))
                {
                    matches = matches.Where(band1 => band1.FormedIn == bandSearchInformation.YearOfFormation);
                }

                if (!string.IsNullOrWhiteSpace(bandSearchInformation.LyricalThemes))
                {
                    matches = matches.Where(band1 => band1.LyricalThemes == bandSearchInformation.LyricalThemes);
                }

                return matches.ToList();
            }

        }

        private Expression BandCountryIsEqual(ParameterExpression band, string countryOfOrigin)
        {
            var bandCountryMatch = Expression.Equal(Expression.Property(band, "CountryOfOrgin"),
                   Expression.Constant(countryOfOrigin));

            return bandCountryMatch;
        }

        private Expression BandGenreIsEqual(ParameterExpression band, string genre)
        {
            var bandCountryMatch = Expression.Equal(Expression.Property(band, "Genre"),
                   Expression.Constant(genre));

            return bandCountryMatch;
        }

    }

    public static class ExpressionExtenstion
    {
        public static Expression Like(this Expression e, string s)
        {
            return Expression.Call(e, "Contains", null, Expression.Constant(s));
        }
    }

}
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using CsvHelper;
using MusicArchive.Models;

namespace MusicArchive.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<MusicArchiveContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MusicArchiveContext context)
        {
            #region Beherit

            var beheritBandImage = File.ReadAllBytes(MapPath(@"~\seedData\beherit.jpg"));
            var beheritLogo = File.ReadAllBytes(MapPath(@"~\seedData\beherit_logo.jpg"));

            var beherit = new Band
            {
                Name = "Beherit",
                CountryOfOrgin = "Finland",
                Description = "Beherit is Syriac for Satan. They also released the demo \"Down There...\" under the name The Lord Diabolus, because of the previous" +
                              "problem with Turbo Music. Both H418ov21.C and Electric Doom Synthesis are not metal albums, but rather synth - based ambient \"dark ritual music\"," +
                              "which NHV released by himself while attempting to put together a full band between 1994 - 1996. Around the same time Beherit started to release ambient" +
                              "albums, NHV had semi - lost his interest in playing metal and started working again as a techno DJ under the name Gamma-G and he even released one" +
                              "compilation CD entitled \"(G)raveyard 2001 - The Ultimate Hardrave Massacre\".",
                Albums = new List<Album>(),
                FormedIn = "1989",
                Genre = "Black Metal",
                Location = "Rovaniemi (early), Helsinki (later)",
                LyricalThemes = "Occult, Darkness, Mysticism",
                YearsActive = "1988 - present",
                BandLogo = beheritLogo,
                BandImage = beheritBandImage
            };

            var drawingDownTheMoon = new Album
            {
                AlbumArtist = beherit,
                Name = "Drawing Down the Moon",
                Type = "Full-length",
                ReleaseDate = "November 13th, 1993",
                Tracks = new List<Track>(),
                Cover = File.ReadAllBytes(MapPath(@"~\seedData\drawingDownTheMoon.jpg")),
                CatalogId = "SPI 14"
            };

            drawingDownTheMoon.Tracks.Add(new Track { Name = "Intro (Tireheb)", Lyrics = "", TrackNumber = 1 });
            drawingDownTheMoon.Tracks.Add(new Track { Name = "Salomon's Gate", Lyrics = "", TrackNumber = 2 });
            drawingDownTheMoon.Tracks.Add(new Track { Name = "Nocturnal Evil", Lyrics = "", TrackNumber = 3 });
            drawingDownTheMoon.Tracks.Add(new Track { Name = "Sadomatic Rites", Lyrics = "", TrackNumber = 4 });
            drawingDownTheMoon.Tracks.Add(new Track { Name = "Black Arts", Lyrics = "", TrackNumber = 5 });
            drawingDownTheMoon.Tracks.Add(new Track { Name = "The Gate of Nanna", Lyrics = "", TrackNumber = 6 });
            drawingDownTheMoon.Tracks.Add(new Track { Name = "Nuclear Girl", Lyrics = "", TrackNumber = 7 });
            drawingDownTheMoon.Tracks.Add(new Track { Name = "Unholy Pagan Fire", Lyrics = "", TrackNumber = 8 });
            drawingDownTheMoon.Tracks.Add(new Track { Name = "Down There...", Lyrics = "", TrackNumber = 9 });
            drawingDownTheMoon.Tracks.Add(new Track { Name = "Summerlands", Lyrics = "", TrackNumber = 10 });
            drawingDownTheMoon.Tracks.Add(new Track { Name = "Werewolf", Lyrics = "", TrackNumber = 11 });
            drawingDownTheMoon.Tracks.Add(new Track { Name = "Thou Angel of the Gods", Lyrics = "", TrackNumber = 12 });
            drawingDownTheMoon.Tracks.Add(new Track { Name = "Lord of Shadows and Goldenwood", Lyrics = "", TrackNumber = 13 });

            beherit.Albums.Add(drawingDownTheMoon);
            context.Albums.Add(drawingDownTheMoon);
        
            var electricDoomSynthesis = new Album
            {
                AlbumArtist = beherit,
                Name = "Electric Doom Synthesis",
                Type = "Full-length",
                ReleaseDate = "June 6th, 1996",
                Cover = File.ReadAllBytes(MapPath(@"~\seedData\electricDoomSynthesis.jpg"))
            };

            beherit.Albums.Add(electricDoomSynthesis);
            context.Albums.Add(electricDoomSynthesis);
            context.Bands.Add(beherit);

            #endregion

            #region Mitochondrion

            var mitochondrion = new Band
            {
                Name = "Mitochondrion",
                CountryOfOrgin = "Canada",
                Albums = new List<Album>(),
                FormedIn = "2003",
                Genre = "Death / Black Metal",
                Location = "Vancouver, British Columbia",
                LyricalThemes = "Apocalypse, Occultism, Disease, Gnosis",
                YearsActive = "2003-present",
            };

            var parasignosis = new Album
            {
                AlbumArtist = mitochondrion,
                Name = "Parasignosis",
                Type = "Full-length",
                ReleaseDate = "January 18th, 2011"

            };
            mitochondrion.Albums.Add(parasignosis);
            context.Albums.Add(parasignosis);
            context.Bands.Add(mitochondrion);

            #endregion

            #region Misþyrming
            var misþyrming = new Band
            {
                Name = "Misþyrming",
                CountryOfOrgin = "Iceland",
                Albums = new List<Album>(),
                FormedIn = "2013",
                Genre = "Black Metal",
                Location = "Reykjavík",
                LyricalThemes = "Darkness, Suffering, Chaos, Death",
                YearsActive = "2013 - present",
            };

            var söngvarEldsOgOreiðu = new Album
            {
                AlbumArtist = misþyrming,
                Name = "Söngvar elds og óreiðu",
                Type = "Full-length",
                ReleaseDate = "November 13th, 1993"
            };
            misþyrming.Albums.Add(söngvarEldsOgOreiðu);
            context.Albums.Add(söngvarEldsOgOreiðu);
            context.Bands.Add(misþyrming);

            #endregion

            BulkLoadSeedDataFromCsv(context);
            LoadBlackSabbathAlbums(context);

            context.SaveChanges();
        }

        private void LoadBlackSabbathAlbums(MusicArchiveContext context)
        {
            using (var reader = new CsvReader(new StreamReader(MapPath(@"~\seedData\blackSabbathDisography.csv"))))
            {
                var blackSabbath = context.Bands.Local.Single(band => band.Name == "Black Sabbath");

                blackSabbath.Description =
                    "Black Sabbath are generally considered both the first heavy metal and doom metal band." +
                    "Originally they were called Polka Tulk (featuring a saxophonist and slide guitarist in their line-up) before changing to Earth," +
                    "a name they had to change again because of confusion with another band of the same name. They may have also went by the name " +
                    "The Earth Blues Company in their pre-Black Sabbath days. Originally, they started as a blues - influenced hard rock group, " +
                    "but as they progressed they added more European folk elements to their sound, a sound that wasn't like any other group during their time." +
                    "Thus, this was known as heavy metal, and in due time, the band became what is now known as doom metal." +
                    "Their lyrics dealt with darker issues than most conventional rock as well. Accordingly, the \"doom\" genre name came from their \"Paranoid\"" +
                    " release, with the song called \"Hand of Doom.\" Stoner metal is another sub - genre that is a direct descendant from this band." +
                    "The \"Mob Rules\" line - up of Tony Iommi, Geezer Butler, Ronnie James Dio and Vinny Appice reunited in 2007." +
                    "Rather than using the Black Sabbath name (as the original line - up is still officially in place), they were called Heaven & Hell, " +
                    "after the first Dio-era album.Three new tracks were recorded for a compilation album of Dio - era Sabbath material before they officially " +
                    "reformed under the Heaven and Hell name. On May 13th 2006, Black Sabbath were inducted into the Rock and Roll Hall of Fame, becoming" +
                    " arguably the first heavy metal band to receive that honor. On November 11, 2011, the original members of Black Sabbath officially" +
                    " announced that they would record a new album and tour again in 2012. On May 19th, 2012, Geezer Butler announced that Tommy Clufetos" +
                    " would be the drummer for the band at three live shows.Original drummer Bill Ward has issued a statement saying that he would not join" +
                    " the reunion because of an \"un-signable contract\". On September 3rd, 2015, Black Sabbath announced that they will embark on their final tour," +
                    "titled \"The End\", from January to September 2016.";

                blackSabbath.BandImage = File.ReadAllBytes(MapPath(@"~\seedData\BlackSabbath.jpg"));
                blackSabbath.BandLogo = File.ReadAllBytes(MapPath(@"~\seedData\BlackSabbath_Logo.jpg"));


                blackSabbath.Albums = new List<Album>();

                while (reader.Read())
                {
                    var name = reader[0];
                    var type = reader[1];
                    var year = reader[2];

                    var album = new Album
                    {
                        Name = name,
                        Type = type,
                        ReleaseDate = year,
                        BandId = blackSabbath.Id,
                        AlbumArtist = blackSabbath
                    };

                    blackSabbath.Albums.Add(album);

                    context.Albums.Add(album);
                }
            }
        }

        private void BulkLoadSeedDataFromCsv(MusicArchiveContext context)
        {
            using (var reader = new CsvReader(new StreamReader(MapPath(@"~\seedData\BandSeedData.csv"))))
            {
                while (reader.Read())
                {
                    var name = reader[0];
                    var countryOfOrigin = reader[1];
                    var genre = reader[2];
                    var status = reader[3];

                    var band = new Band
                    {
                        Name = name,
                        CountryOfOrgin = countryOfOrigin,
                        Genre = genre,
                        Status = status
                    };

                    context.Bands.Add(band);
                }
            }
        }

        private string MapPath(string seedFile)
        {
            if (HttpContext.Current != null)
                return HostingEnvironment.MapPath(seedFile);

            var localPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            var directoryName = Path.GetDirectoryName(localPath);
            var path = Path.Combine(directoryName, ".." + seedFile.TrimStart('~').Replace('/', '\\'));

            return path;
        }
    }
}

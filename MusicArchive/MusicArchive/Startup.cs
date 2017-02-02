using System;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Microsoft.Owin;
using MusicArchive;
using MusicArchive.Controllers;
using MusicArchive.Models;
using MusicArchive.Repositories;
using Newtonsoft.Json.Serialization;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace MusicArchive
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            GlobalConfiguration.Configure(WebApiConfig.Register);
            HttpConfiguration config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            // Dependency Injection Setup
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule(new MusicArchiveContainer());

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            SetupAutoMapper();
        }

        private void SetupAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Band, BandSearchRowDto>()
                    .ForMember(dto => dto.BandImage, expression => expression.MapFrom(band => EncodeImage(band.BandImage)));


                cfg.CreateMap<Band, BandDetailDto>()
                     .ForMember(dto => dto.BandImage, expression => expression.MapFrom(band => EncodeImage(band.BandImage)))
                     .ForMember(dto => dto.BandLogo, expression => expression.MapFrom(band => EncodeImage(band.BandLogo)));

                cfg.CreateMap<Album, BandAlbumDto>()
                    .ForMember(dto => dto.Cover, expression => expression.MapFrom(album => EncodeImage(album.Cover)));


                cfg.CreateMap<Track, TrackDto>();
                cfg.CreateMap<Review, ReviewDto>();

                cfg.CreateMap<Album, AlbumDetailDto>()
                    .ForMember(dto => dto.BandName, expression => expression.MapFrom(album => album.AlbumArtist.Name))
                    .ForMember(dto => dto.Tracks, expression => expression.MapFrom(album => album.Tracks))
                    .ForMember(dto => dto.AlbumArt, expression => expression.MapFrom(album => EncodeImage(album.Cover)));
            });
        }

        private string EncodeImage(byte[] imageData)
        {
            return string.Format("{0}{1}", "data:image/png;base64,", Convert.ToBase64String(imageData));
        }
    }
}

using Autofac;
using MusicArchive.Controllers;
using MusicArchive.Repositories;

namespace MusicArchive
{
    public class MusicArchiveContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new SearchRepository()).As<ISearchRepository>().InstancePerRequest();
            builder.Register(context => new BandRepository()).As<IBandRepository>().InstancePerRequest();
            builder.Register(context => new AlbumRepository()).As<IAlbumRepository>().InstancePerRequest();
            base.Load(builder);
        }
    }
}
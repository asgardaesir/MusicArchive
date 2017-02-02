namespace MusicArchive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        ReleaseDate = c.String(),
                        Rating = c.String(),
                        BandId = c.Guid(nullable: false),
                        CatalogId = c.String(),
                        Format = c.String(),
                        Cover = c.Binary(),
                        Label_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bands", t => t.BandId, cascadeDelete: true)
                .ForeignKey("dbo.Labels", t => t.Label_Id)
                .Index(t => t.BandId)
                .Index(t => t.Label_Id);
            
            CreateTable(
                "dbo.Bands",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CountryOfOrgin = c.String(),
                        Location = c.String(),
                        Status = c.String(),
                        FormedIn = c.String(),
                        YearsActive = c.String(),
                        Genre = c.String(),
                        LyricalThemes = c.String(),
                        BandLogo = c.Binary(),
                        BandImage = c.Binary(),
                        CurrentLabel_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Labels", t => t.CurrentLabel_Id)
                .Index(t => t.CurrentLabel_Id);
            
            CreateTable(
                "dbo.Labels",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Band_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bands", t => t.Band_Id)
                .Index(t => t.Band_Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ReviewText = c.String(),
                        Rating = c.Single(nullable: false),
                        Album_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.Album_Id)
                .Index(t => t.Album_Id);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        TrackNumber = c.Int(nullable: false),
                        Name = c.String(),
                        Lyrics = c.String(),
                        AlbumId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .Index(t => t.AlbumId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.Reviews", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.Albums", "Label_Id", "dbo.Labels");
            DropForeignKey("dbo.Artists", "Band_Id", "dbo.Bands");
            DropForeignKey("dbo.Bands", "CurrentLabel_Id", "dbo.Labels");
            DropForeignKey("dbo.Albums", "BandId", "dbo.Bands");
            DropIndex("dbo.Tracks", new[] { "AlbumId" });
            DropIndex("dbo.Reviews", new[] { "Album_Id" });
            DropIndex("dbo.Artists", new[] { "Band_Id" });
            DropIndex("dbo.Bands", new[] { "CurrentLabel_Id" });
            DropIndex("dbo.Albums", new[] { "Label_Id" });
            DropIndex("dbo.Albums", new[] { "BandId" });
            DropTable("dbo.Tracks");
            DropTable("dbo.Reviews");
            DropTable("dbo.Artists");
            DropTable("dbo.Labels");
            DropTable("dbo.Bands");
            DropTable("dbo.Albums");
        }
    }
}

namespace MusicArchive.Models
{
    public class NewBandBindingModel
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string YearOfFormation { get; set; }
        public string CountryOfOrigin { get; set; }
        public TagBindingModel[] LyricalThemes { get; set; }
        public string Label { get; set; }
    }

    public class TagBindingModel
    {
        public string Text { get; set; }
    }
}
namespace MusicArchive
{
    public class BandSearchInformation
    {
        private string _bandName;
        public string BandName
        {
            get { return _bandName; }
            set { _bandName = value?.ToLower() ?? string.Empty; }
        }

        public string CountryOfOrigin { get; set; }
        public string Label { get; set; }
        public string LyricalThemes { get; set; }
        public string Genre { get; set; }
        public string YearOfFormation { get; set; }
    }
}
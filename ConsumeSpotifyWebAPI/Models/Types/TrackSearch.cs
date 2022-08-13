namespace ConsumeSpotifyWebAPI.Models.Types
{
    public class TrackSearch
    {
        public string Name { get; set; }
        public string AlbumName { get; set; }
        public string Artists { get; set; }
        public int Duration { get; set; }
        public bool Explicit { get; set; }
        public int Popularity { get; set; }
        public string ReleaseDate { get; set; }
        public string ImageUrl { get; set; }
        public string Link { get; set; }
    }
}

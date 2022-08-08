namespace ConsumeSpotifyWebAPI.Models.Types
{
    public class AlbumSearch        // albums.items
    {
        public string Name { get; set; }    // name
        public string Artists { get; set; } // release_date
        public string Date { get; set; }    // images.FirstOrDefault().url
        public string ImageUrl { get; set; } // externam_urls.spotify
        public string Link { get; set; }    // string.Join(",", i.artists.Select(i => i.name))
    }
}

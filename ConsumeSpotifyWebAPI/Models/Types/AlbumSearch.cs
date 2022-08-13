namespace ConsumeSpotifyWebAPI.Models.Types
{
    public class AlbumSearch        // albums.items
    {
        public string Name { get; set; }    // name
        public string Artists { get; set; } // string.Join(",", i.artists.Select(i => i.name))
        public string Date { get; set; }    // release_date
        public string ImageUrl { get; set; } // images.FirstOrDefault().url
        public string Link { get; set; }    // external_urls.spotify
    }
}

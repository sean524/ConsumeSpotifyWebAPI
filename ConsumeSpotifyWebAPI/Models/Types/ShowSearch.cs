namespace ConsumeSpotifyWebAPI.Models.Types
{
    public class ShowSearch
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Explicit { get; set; }
        public string Publisher { get; set; }
        /*public string Languages { get; set; }*/
        public int NumOfEpisodes { get; set; }
        public string ImageUrl { get; set; }
        public string Link { get; set; }
    }
}

using ConsumeSpotifyWebAPI.Models;

namespace ConsumeSpotifyWebAPI.Services
{
    public interface ISpotifyService
    {
        Task<IEnumerable<Release>> GetNewReleases(string countryCode, int limit, string accessToken);
        Task<IEnumerable<Release>> GetNewAlbums(string search, string type, int limit, string accessToken);
        Task<IEnumerable<ArtistSearch>> GetNewArtists(string search, string type, int limit, string accessToken);
        Task<IEnumerable<Release>> GetNewPlaylists(string search, string type, int limit, string accessToken);
        Task<IEnumerable<Release>> GetNewTasks(string search, string type, int limit, string accessToken);
        Task<IEnumerable<Release>> GetNewShows(string search, string type, int limit, string accessToken);
        Task<IEnumerable<Release>> GetNewEpisodes(string search, string type, int limit, string accessToken);
    }
}

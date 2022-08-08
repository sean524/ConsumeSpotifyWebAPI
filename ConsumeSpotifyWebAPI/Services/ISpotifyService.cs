using ConsumeSpotifyWebAPI.Models.Types;

namespace ConsumeSpotifyWebAPI.Services
{
    public interface ISpotifyService
    {
        Task<IEnumerable<AlbumSearch>> GetNewReleases(string countryCode, int limit, string accessToken);
        Task<IEnumerable<AlbumSearch>> GetNewAlbums(string search, string type, int limit, string accessToken);
        Task<IEnumerable<ArtistSearch>> GetNewArtists(string search, string type, int limit, string accessToken);
        Task<IEnumerable<AlbumSearch>> GetNewPlaylists(string search, string type, int limit, string accessToken);
        Task<IEnumerable<AlbumSearch>> GetNewTasks(string search, string type, int limit, string accessToken);
        Task<IEnumerable<AlbumSearch>> GetNewShows(string search, string type, int limit, string accessToken);
        Task<IEnumerable<AlbumSearch>> GetNewEpisodes(string search, string type, int limit, string accessToken);
    }
}

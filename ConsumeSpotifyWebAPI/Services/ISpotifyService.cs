using ConsumeSpotifyWebAPI.Models.Types;

namespace ConsumeSpotifyWebAPI.Services
{
    public interface ISpotifyService
    {
        Task<IEnumerable<AlbumSearch>> GetNewReleases(string countryCode, int limit, string accessToken);
        Task<IEnumerable<AlbumSearch>> GetNewAlbums(string search, string type, int limit, string accessToken);
        Task<IEnumerable<ArtistSearch>> GetNewArtists(string search, string type, int limit, string accessToken);
        Task<IEnumerable<PlaylistSearch>> GetNewPlaylists(string search, string type, int limit, string accessToken);
        Task<IEnumerable<TrackSearch>> GetNewTracks(string search, string type, int limit, string accessToken);
        Task<IEnumerable<ShowSearch>> GetNewShows(string search, string type, int limit, string accessToken);
        Task<IEnumerable<EpisodeSearch>> GetNewEpisodes(string search, string type, int limit, string accessToken);
    }
}

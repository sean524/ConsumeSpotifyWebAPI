using ConsumeSpotifyWebAPI.Models.Types;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ConsumeSpotifyWebAPI.Services
{
    public class SpotifyService : ISpotifyService
    {
        private readonly HttpClient _httpClient;
        public SpotifyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public HttpClient HttpClient { get; }

        public async Task<IEnumerable<AlbumSearch>?> GetNewReleases(string countryCode, int limit, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync($"browse/new-releases?country={countryCode}&offset=0&limit={limit}");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetNewReleaseResult>(responseStream);

            return responseObject?.albums?.items.Select(i => new AlbumSearch
            {
                Name = i.name,
                Date = i.release_date,
                ImageUrl = i.images.FirstOrDefault().url,
                Link = i.external_urls.spotify,
                Artists = string.Join(",", i.artists.Select(i => i.name))
            });
        }

        public async Task<IEnumerable<AlbumSearch>?> GetNewAlbums(string search, string type, int limit, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync($"search?q={search}&type={type}&limit={limit}");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetNewReleaseResult>(responseStream);

            return responseObject?.albums?.items.Select(i => new AlbumSearch
            {
                Name = i.name,
                Date = i.release_date,
                ImageUrl = i.images.FirstOrDefault().url,
                Link = i.external_urls.spotify,
                Artists = string.Join(",", i.artists.Select(i => i.name))
            });
        }

        public async Task<IEnumerable<ArtistSearch>?> GetNewArtists(string search, string type, int limit, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync($"search?q={search}&type={type}");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetArtistResult>(responseStream);

            return responseObject?.artists?.items.Select(i => new ArtistSearch
            {
                Name = i.name,
                Followers = i.followers.total,
                ImageUrl = i.images.FirstOrDefault()?.url,
                Link = i.external_urls.spotify
            });
        }

        public async Task<IEnumerable<PlaylistSearch>?> GetNewPlaylists(string search, string type, int limit, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync($"search?q={search}&type={type}&limit={limit}");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetPlaylistResults>(responseStream);

            return responseObject?.playlists?.items.Select(i => new PlaylistSearch
            {
                Name = i.name,
                OwnerName = i.owner.display_name,
                Description = i.description,
                ImageUrl = i.images.FirstOrDefault().url,
                Link = i.external_urls.spotify
            });
        }

        public async Task<IEnumerable<TrackSearch>?> GetNewTracks(string search, string type, int limit, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync($"search?q={search}&type={type}&limit={limit}");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetTrackResults>(responseStream);

            return responseObject?.tracks?.items.Select(i => new TrackSearch
            {
                Name = i.name,
                AlbumName = i.album.name,
                Artists = string.Join(",", i.artists.Select(i => i.name)),
                Duration = i.duration_ms,
                Explicit = i._explicit,
                Popularity = i.popularity,
                ReleaseDate = i.album.release_date,
                ImageUrl = i.album.images.FirstOrDefault().url,
                Link = i.external_urls.spotify,
            });
        }

        public async Task<IEnumerable<ShowSearch>?> GetNewShows(string search, string type, int limit, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync($"search?q={search}&type={type}");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetShowResults>(responseStream);

            return responseObject?.shows?.items.Select(i => new ShowSearch
            {
                Name = i.name,
                Description = i.description,
                Explicit = i._explicit,
                Publisher = i.publisher,
                NumOfEpisodes = i.total_episodes,
                ImageUrl = i.images.FirstOrDefault().url,
                Link = i.external_urls.spotify
            });
        }

        public async Task<IEnumerable<EpisodeSearch>?> GetNewEpisodes(string search, string type, int limit, string accessToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync($"search?q={search}&type={type}");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetEpisodeResults>(responseStream);

            return responseObject?.episodes?.items.Select(i => new EpisodeSearch
            {
                Name = i.name,
                Description = i.description,
                ImageUrl = i.images.FirstOrDefault().url,
                ReleaseDate = i.release_date,
                Link = i.external_urls.spotify
            });
        }
    }
}

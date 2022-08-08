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

        public async Task<IEnumerable<AlbumSearch>> GetNewReleases(string countryCode, int limit, string accessToken)
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

            var response = await _httpClient.GetAsync($"search?q={search}&type={type}&limit={limit}");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseObject = await JsonSerializer.DeserializeAsync<GetArtistResult>(responseStream);

            return responseObject?.artists?.items.Select(i => new ArtistSearch
            {
                Name = i.name,
                Followers = i.followers.total,
                ImageUrl = i.images.FirstOrDefault().url,
                Link = i.external_urls.spotify
            });
        }

        public Task<IEnumerable<AlbumSearch>> GetNewPlaylists(string search, string type, int limit, string accessToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AlbumSearch>> GetNewTasks(string search, string type, int limit, string accessToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AlbumSearch>> GetNewShows(string search, string type, int limit, string accessToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AlbumSearch>> GetNewEpisodes(string search, string type, int limit, string accessToken)
        {
            throw new NotImplementedException();
        }
    }
}

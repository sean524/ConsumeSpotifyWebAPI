using ConsumeSpotifyWebAPI.Models;
using ConsumeSpotifyWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConsumeSpotifyWebAPI.Controllers
{
    public class SearchController : Controller
    {

        private readonly ISpotifyAccountService _spotifyAccountService;
        private readonly IConfiguration _configuration;
        private readonly ISpotifyService _spotifyService;

        public SearchController(
            ISpotifyAccountService spotifyAccountService,
            IConfiguration configuration,
            ISpotifyService spotifyService)
        {
            _spotifyAccountService = spotifyAccountService;
            _configuration = configuration;
            _spotifyService = spotifyService;
        }

        public async Task<IActionResult> Search(string SearchString, string TypeString)
        {

            switch (TypeString)
            {
                case "album":
                    var albumSearch = await GetAlbums(SearchString, TypeString);
                    return View(albumSearch);
                case "artist":
                    var artistSearch = await GetArtists(SearchString, TypeString);
                    return View("Artists", artistSearch);
/*                case "playlist":
                    var playlistSearch = await GetPlaylists(SearchString, TypeString);
                    return View(playlistSearch);
                case "track":
                    var trackSearch = await GetTracks(SearchString, TypeString);
                    return View(trackSearch);
                case "show":
                    var showSearch = await GetShows(SearchString, TypeString);
                    return View(showSearch);
                case "episode":
                    var episodeSearch = await GetEpisodes(SearchString, TypeString);
                    return View(episodeSearch);*/
            }
            return View();
        }

        private async Task<IEnumerable<Release>> GetAlbums(string SearchString, string TypeString)
        {
            try
            {
                var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);

                var newSearches = await _spotifyService.GetNewAlbums(SearchString, TypeString, 20, token);

                return newSearches;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);

                return Enumerable.Empty<Release>();
            }
        }

        private async Task<IEnumerable<ArtistSearch>> GetArtists(string SearchString, string TypeString)
        {
            try
            {
                var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);

                var newSearches = await _spotifyService.GetNewArtists(SearchString, TypeString, 10, token);

                return newSearches;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);

                return Enumerable.Empty<ArtistSearch>();
            }
        }

/*        private async Task<IEnumerable<Playlist>> GetPlaylists(string SearchString, string TypeString)
        {
            try
            {
                var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);

                var newSearches = await _spotifyService.GetNewSearches(SearchString, TypeString, 20, token);

                return newSearches;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);

                return Enumerable.Empty<Artist>();
            }
        }

        private async Task<IEnumerable<Track>> GetTracks(string SearchString, string TypeString)
        {
            try
            {
                var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);

                var newSearches = await _spotifyService.GetNewSearches(SearchString, TypeString, 20, token);

                return newSearches;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);

                return Enumerable.Empty<Artist>();
            }
        }

        private async Task<IEnumerable<Show>> GetShows(string SearchString, string TypeString)
        {
            try
            {
                var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);

                var newSearches = await _spotifyService.GetNewSearches(SearchString, TypeString, 20, token);

                return newSearches;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);

                return Enumerable.Empty<Artist>();
            }
        }

        private async Task<IEnumerable<Episode>> GetEpisodes(string SearchString, string TypeString)
        {
            try
            {
                var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);

                var newSearches = await _spotifyService.GetNewSearches(SearchString, TypeString, 20, token);

                return newSearches;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);

                return Enumerable.Empty<Artist>();
            }
        }*/
    }
}

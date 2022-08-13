using ConsumeSpotifyWebAPI.Models.Types;
using ConsumeSpotifyWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

/*
 * Not working right:
 * -Playlist    (not showing anything)
 * -Show        (NullReferenceException in GetNewShows)
 * -Episode     (not showing anything)
 */

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
                case "playlist":
                    var playlistSearch = await GetPlaylists(SearchString, TypeString);
                    return View("Playlists", playlistSearch);
                case "track":
                    var trackSearch = await GetTracks(SearchString, TypeString);
                    return View("Tracks", trackSearch);
                case "show":
                    var showSearch = await GetShows(SearchString, TypeString);
                    return View("Shows", showSearch);
                case "episode":
                    var episodeSearch = await GetEpisodes(SearchString, TypeString);
                    return View("Episodes", episodeSearch);
            }
            return View();
        }

        private async Task<IEnumerable<AlbumSearch>> GetAlbums(string SearchString, string TypeString)
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

                return Enumerable.Empty<AlbumSearch>();
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

        private async Task<IEnumerable<PlaylistSearch>> GetPlaylists(string SearchString, string TypeString)
        {
            try
            {
                var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);

                var newSearches = await _spotifyService.GetNewPlaylists(SearchString, TypeString, 10, token);

                return newSearches;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                return Enumerable.Empty<PlaylistSearch>();
            }
        }

        private async Task<IEnumerable<TrackSearch>> GetTracks(string SearchString, string TypeString)
        {
            try
            {
                var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);

                var newSearches = await _spotifyService.GetNewTracks(SearchString, TypeString, 20, token);

                return newSearches;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);

                return Enumerable.Empty<TrackSearch>();
            }
        }

        private async Task<IEnumerable<ShowSearch>> GetShows(string SearchString, string TypeString)
        {
            try
            {
                var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);

                var newSearches = await _spotifyService.GetNewShows(SearchString, TypeString, 5, token);

                return newSearches;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);

                return Enumerable.Empty<ShowSearch>();
            }
        }

        private async Task<IEnumerable<EpisodeSearch>> GetEpisodes(string SearchString, string TypeString)
        {
            try
            {
                var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);

                var newSearches = await _spotifyService.GetNewEpisodes(SearchString, TypeString, 20, token);

                return newSearches;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);

                return Enumerable.Empty<EpisodeSearch>();
            }
        }
    }
}

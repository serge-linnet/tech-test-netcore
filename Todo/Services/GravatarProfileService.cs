using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Todo.Models.Gravatar;

namespace Todo.Services
{
    public interface IGravatarProfileService
    {
        Task<string> GetUserName(string email);
    }

    /// <summary>
    /// Service for fetching Gravatar profiles.
    /// </summary>
    public class GravatarProfileService : IGravatarProfileService
    {
        private readonly ILogger<GravatarProfileService> _logger;

        public GravatarProfileService(ILogger<GravatarProfileService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Returns user display name from Gravatar profile.
        /// </summary>
        /// <param name="email">User email.</param>
        public async Task<string> GetUserName(string email)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Todo/1.0");

            var hash = Gravatar.GetHash(email);
            var response = await httpClient.GetAsync($"https://www.gravatar.com/{hash}.json");
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Unable to retrieve user profile from Gravatar (status Code: {response.StatusCode}).");
                return null;
            }

            var profile = await response.Content.ReadFromJsonAsync<GravatarProfile>();
            var entry = profile?.Entry?.FirstOrDefault(profile => profile.Hash == hash);

            return entry?.DisplayName;
        }
    }
}

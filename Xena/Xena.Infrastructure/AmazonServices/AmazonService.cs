using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Xena.Application.Abstractions.AmazonServices;
using Xena.Domain.AmazonServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Memory;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Xena.Infrastructure.AmazonServices
{
    public class AmazonService : IAmazonService
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private IMemoryCache _cache;
        private const string _accessTokenCacheKey = "AccessTokenCacheKey";
        private AmazonConfig _amazonConfig = new AmazonConfig();
        public AmazonService(IConfiguration config, IMapper mapper, IMemoryCache cache)
        {
            _mapper = mapper;
            _config = config;
            _cache = cache;
            config.Bind("AmazonConfig", _amazonConfig);
        }

        public async Task<string> GetProfilesAsync(int userId)
        {
            var accessToken = await GetUserAccessTokenAsync(userId);
            using (var httpClient = new HttpClient())
            {
                AddUserAgentHeader(httpClient);

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(accessToken.token_type, accessToken.access_token);
                httpClient.DefaultRequestHeaders.Add("Amazon-Advertising-API-ClientId", _amazonConfig.ClientId);
                var response = await httpClient.GetAsync(_amazonConfig.ProfileUrl);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }
            }
            return null;
        }

        public async Task<string> GetAdGroupsAsync(int userId, long profileId)
        {
            var accessToken = await GetUserAccessTokenAsync(userId);
            using (var httpClient = new HttpClient())
            {
                AddUserAgentHeader(httpClient);

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(accessToken.token_type, accessToken.access_token);
                httpClient.DefaultRequestHeaders.Add("Amazon-Advertising-API-ClientId", _amazonConfig.ClientId);
                httpClient.DefaultRequestHeaders.Add("Amazon-Advertising-API-Scope", profileId.ToString());
                
                var response = await httpClient.GetAsync(_amazonConfig.AdGroupUrl);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }
            }
            return null;
        }

        public async Task<string> GetCampaignsAsync(int userId, long profileId)
        {
            var accessToken = await GetUserAccessTokenAsync(userId);
            using (var httpClient = new HttpClient())
            {
                AddUserAgentHeader(httpClient);

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(accessToken.token_type, accessToken.access_token);
                httpClient.DefaultRequestHeaders.Add("Amazon-Advertising-API-ClientId", _amazonConfig.ClientId);
                httpClient.DefaultRequestHeaders.Add("Amazon-Advertising-API-Scope", profileId.ToString());
                var response = await httpClient.GetAsync(_amazonConfig.CampaignUrl);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }
            }
            return null;
        }

        public async Task<string> GetKeywordsAsync(int userId, long profileId)
        {
            var accessToken = await GetUserAccessTokenAsync(userId);
            using (var httpClient = new HttpClient())
            {
                AddUserAgentHeader(httpClient);

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(accessToken.token_type, accessToken.access_token);
                httpClient.DefaultRequestHeaders.Add("Amazon-Advertising-API-ClientId", _amazonConfig.ClientId);
                httpClient.DefaultRequestHeaders.Add("Amazon-Advertising-API-Scope", profileId.ToString());
                var response = await httpClient.GetAsync(_amazonConfig.KeywordsUrl);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }
            }
            return null;
        }

        private void AddUserAgentHeader(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.UserAgent.Add(
                new ProductInfoHeaderValue(
                    _config.GetSection("UserAgentHeader:ProductName").Value,
                    _config.GetSection("UserAgentHeader:ProductVersion").Value));
        }

        public async Task<AccessToken> GetUserAccessTokenAsync(int userId)
        {
            AccessToken cacheResult;
            string cachekey = string.Format("{0}_{1}", _accessTokenCacheKey, userId);
            // Look for cache key.
            if (!_cache.TryGetValue(cachekey, out cacheResult))
            {
                string refreshToken = GetRefreshToken(userId);

                using (var httpClient = new HttpClient())
                {
                    AddUserAgentHeader(httpClient);

                    var parameters = new Dictionary<string, string>();
                    parameters.Add("Content-Type", "application/x-www-form-urlencoded");
                    parameters.Add("charset", "UTF-8");
                    parameters.Add("client_id", _amazonConfig.ClientId);
                    parameters.Add("client_secret", _amazonConfig.ClientSecret);
                    parameters.Add("redirect_uri", _amazonConfig.RedirectUri);
                    parameters.Add("refresh_token", refreshToken);
                    parameters.Add("grant_type", "refresh_token");

                    var response = await httpClient.PostAsync(_amazonConfig.AccessTokenUrl, new FormUrlEncodedContent(parameters));

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        cacheResult = JsonConvert.DeserializeObject<AccessToken>(result);
                        var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(cacheResult.expires_in - 300d));
                        _cache.Set(cachekey, cacheResult, cacheEntryOptions);
                    }
                }
            }
            return cacheResult;
        }

        private string GetRefreshToken(int userId)
        {
            // TODO: Get it from DB. Time being hard coded for testing.
            return "Atzr|IwEBIPmeP4k5MEY_sbNvq0t-xXsqOenVDLsbjSISc7v-tiOZUT9DLq6nmUpQNuht-R2A3McKcKv60N7S6MIVbqHzzs8m96PXsKi2O9FrJ16KBKhuU8fkUv-J3QLhb772anZ-AC275hhiq7MILj6vWBfhBWgZTE-4c-8f3LGFuzpamXUpN-_KN0kk0YMyCiKfj1W3HCAt2X1wkx0_3DIm-dB0O-Yp6TZlbt6YuLLik_frp42zHFqvb9u0I8Y6OhrHz4aMjfhaezeKa3UiPqoKF1AwwhJ93jx_IwiQ9sz0QSFwbQSWyJ4Z7O7b4Dn2PseQN7YaGRzavd2whzNK2jQfrE26XxMCFr-C9UKe05DucsDJSwzhj9NP0yphkfDEjHQPXPguCDZsaqhj0z8VFIVi6-LUwibOP7J9H5W_6Vyj9txxkIbtp_DQgqSqSJhwNDwqrdY7uxM";
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Voicify.Sdk.Webhooks.Data;

namespace SpotifyVoicifySample.Providers
{
    public class SpotifyDataProvider : HttpDataProvider
    {
        private string _accessToken;
        public SpotifyDataProvider(HttpClient client) : base(client)
        {
        }

        protected override Task SetTokenAsync()
        {
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_accessToken}");
            return Task.CompletedTask;
        }

        public void SetToken(string accessToken)
        {
            _accessToken = accessToken;
        }
    }
}

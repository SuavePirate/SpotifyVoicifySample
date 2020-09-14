using Microsoft.AspNetCore.Mvc;
using ServiceResult;
using SpotifyVoicifySample.Models;
using SpotifyVoicifySample.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Voicify.Sdk.Core.Models.Webhooks.Requests;
using Voicify.Sdk.Webhooks.Data;
using Voicify.Sdk.Webhooks.Data.Definitions;
using Voicify.Sdk.Webhooks.Services;
using Voicify.Sdk.Webhooks.Services.Definitions;

namespace SpotifyVoicifySample.Controllers
{
    [Route("api/[controller]")]
    public class VoicifyController : Controller
    {
        private readonly IResponseBuilder _responseBuilder;
        private readonly SpotifyDataProvider _spotifyProvider;
        public VoicifyController()
        {
            _responseBuilder = new ResponseBuilder(new FollowUpBuilder());
            _spotifyProvider = new SpotifyDataProvider(new HttpClient());
        }

        [HttpPost("HandleUsername")]
        public async Task<IActionResult> HandleRequest([FromBody]GeneralWebhookFulfillmentRequest request)
        {
            // get the spotify access token from post-account linking
            var accessToken = request?.OriginalRequest?.AccessToken;

            // validate that we have the access token
            if(string.IsNullOrEmpty(accessToken))
                return Ok(_responseBuilder.WithContent("You are not signed in. Please link your spotify account first")
                    .BuildResponse());

            // set it in the http header for future requests
            _spotifyProvider.SetToken(accessToken);

            // get the current spotify user
            var result = await _spotifyProvider.GetJsonAsync<SpotifyUser>("https://api.spotify.com/v1/me");

            // build the response with the user's actual name replacing the {username} variable in the output
            if(result.ResultType == ResultType.Ok)
            {
                return Ok(_responseBuilder.WithContent(request.Response.Content)
                    .WithReplacement("{username}", result.Data.DisplayName)
                    .BuildResponse());
            }
            return Ok();
        }
    }
}

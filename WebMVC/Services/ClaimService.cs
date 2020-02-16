using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using WebMVC.Infrastructure;
using WebMVC.ViewModels;
using System.Net.Http.Headers;

namespace WebMVC.Services
{
    public class ClaimService : IClaimService
    {
        //private HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl;
        private readonly IOptions<AppSettings> _settings;

        //public ClaimService(IOptions<AppSettings> settings)
        //{
        //    //_httpClient = httpClient;
        //    _settings = settings;
        //    _remoteServiceBaseUrl = $"{settings.Value.ClaimUrl}/claims";
        //}

        public ClaimService()
        {
            _remoteServiceBaseUrl = $"http://localhost:5000/claims";


        }
        public async void CreateClaim(ClaimViewModel claim)
        {

            var uri = API.Claim.PostClaim(_remoteServiceBaseUrl);
            var claimContent = new StringContent(JsonConvert.SerializeObject(claim), System.Text.Encoding.UTF8, "application/json");

            //var response = await _httpClient.PutAsync(uri, claimContent);

            //if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            //{
            //    throw new Exception("Error in clim creation process, try later.");
            //}

            //response.EnsureSuccessStatusCode();

           HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsync("api/claims", claimContent);
            response.EnsureSuccessStatusCode();
        }

    }
}

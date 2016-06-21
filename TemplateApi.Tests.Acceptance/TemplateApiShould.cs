using Microsoft.Owin.Hosting;
using NUnit.Framework;
using System;
using TemplateApi.App_Start;
using System.Net.Http;
using Shouldly;
using System.Threading.Tasks;

namespace TemplateApi.Tests.Acceptance
{
    [TestFixture]
    public class TemplateApiShould
    {
        private IDisposable _webApp;
        private const string FIXED_LOCAL_HOST = "http://localhost:9165";
        private const string FIXED_ENDPOINT = "api/home";
        private const string NON_EXISTING_ENDPOINT = "api/default";

        private const string FIXED_RESPONSE = "\"Valar Morghulis\"";
        private HttpClient HttpClient;

        [SetUp]
        public void SetUp()
        {
            _webApp = WebApp.Start<Startup>(FIXED_LOCAL_HOST);
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(FIXED_LOCAL_HOST)
            };
        }

        [Test]
        public async Task Return_Json_With_Information()
        {
            var result = await HttpClient.GetAsync(FIXED_ENDPOINT);
            string content = await result.Content.ReadAsStringAsync();

            content.ShouldBe(FIXED_RESPONSE, Case.Insensitive);
        }


        [Test]
        public async Task Non_Existing_Endpoint_NotFound()
        {
            var result = await HttpClient.GetAsync(NON_EXISTING_ENDPOINT);

            result.StatusCode.ShouldBe(System.Net.HttpStatusCode.NotFound);
        }

        [TearDown]
        public void TearDown()
        {
            _webApp.Dispose();
        }
    }
}

using Microsoft.Owin.Hosting;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TemplateApi.App_Start;
using System.Net.Http;
using Shouldly;

namespace TemplateApi.Tests.Acceptance
{
    [TestFixture]
    public class TemplateApiShould
    {
        private IDisposable _webApp;
        private const string FIXED_LOCAL_HOST = "http://localhost:9165";
        private const string FIXED_ENDPOINT = "api/home/values";
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
        public void Return_Json_With_Information()
        {
            string content;

            var result = HttpClient.GetAsync(FIXED_ENDPOINT).Result;
            content = result.Content.ReadAsStringAsync().Result;

            content.ShouldBe(FIXED_RESPONSE, Case.Insensitive);
        }

        [TearDown]
        public void TearDown()
        {
            _webApp.Dispose();
        }
    }
}

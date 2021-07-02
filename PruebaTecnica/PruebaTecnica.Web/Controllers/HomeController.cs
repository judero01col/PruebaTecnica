using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PruebaTecnica.Application.Wrappers;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Web.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PruebaTecnica.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Index()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:57712/api/v1/Books");
            var client = _clientFactory.CreateClient("Github");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                //var user1 = await JsonSerializer.DeserializeAsync<PagedResponse<List<Book>>>(responseStream);

                StreamReader reader = new StreamReader(responseStream);
                string Json = reader.ReadToEnd();
                var user2 = JsonConvert.DeserializeObject<PagedResponse<List<Book>>>(Json);
            }
            else
            {

            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

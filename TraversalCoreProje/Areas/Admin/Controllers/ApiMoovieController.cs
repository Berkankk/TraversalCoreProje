using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System.Collections.Generic;
using TraversalCoreProje.Areas.Admin.Models;
using Newtonsoft.Json;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ApiMoovieController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ApiMoovieViewModel> apiMoovieViewModels = new List<ApiMoovieViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "x-rapidapi-key", "838b5c03bemsh1fdc2f62ee9ba46p10c0b1jsne57421d8c874" },  //Profil keyi  
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" }, //Sağlayıcı
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiMoovieViewModels = JsonConvert.DeserializeObject<List<ApiMoovieViewModel>>(body);
                return View(apiMoovieViewModels);
            }
        }
    }
}

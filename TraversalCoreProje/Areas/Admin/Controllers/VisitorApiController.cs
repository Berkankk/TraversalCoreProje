using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    //Burada apiyi tüketeceğiz consume işlemlerini yapacağız
    public class VisitorApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VisitorApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var cliet = _httpClientFactory.CreateClient(); //Yeni istek oluşturduk
            var responseMessage = await cliet.GetAsync("https://localhost:44326/api/Visitor"); //İstek listeleme yoksa veri işleme üzerine geri dönüş mesajı oluşturduk
            if (responseMessage.IsSuccessStatusCode) //istek başarılıysa 
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //json türden string türe çevir 
                var values = JsonConvert.DeserializeObject<List<VisitorViewModel>>(jsonData); //String türü okuttuk
                return View(values); //values da gelen değeri dön dedik
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateVisitor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateVisitor(VisitorViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);//Ekleme işlemi yapıldı 
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44326/api/Visitor", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44326/api/Visitor/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> UpdateVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44326/api/Visitor/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<VisitorViewModel>(jsonData);
                return View(values);

            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateVisitor(VisitorViewModel viewModel)
        {
            var client = _httpClientFactory.CreateClient(); //istek oluşturduk
            var jsonData = JsonConvert.SerializeObject(viewModel);//Ekleme işlemi yapıldı 
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44326/api/Visitor", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

    }
}

using Emlak.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Emlak.WebApp.Controllers
{
    [Authorize]
    public class SituationApiController : Controller
    {

        public IActionResult Index()
        {
            HttpClient _httpClient = new HttpClient();

            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token").ToString());

            var request = _httpClient.GetAsync("https://localhost:7115/api/Situations").Result;
            var response = request.Content.ReadAsStringAsync().Result;
            var value = JsonConvert.DeserializeObject<List<Situation>>(response);
            return View(value);
        }

        //Eğer user kullanıcısı tanımlarsak üyeler kendi ilanlarını ekleyebilecekleri için create methodunu yazıyoruz.
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Situation situation)
        {
            HttpClient _httpClient = new HttpClient();

            #region User Token
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token").ToString());
            #endregion

            var status = JsonConvert.SerializeObject(situation);

            StringContent content = new StringContent(status, Encoding.UTF8, "application/json");
            var request = _httpClient.PostAsync("https://localhost:7115/api/Situations", content).Result;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            HttpClient _httpClient = new HttpClient();

            #region User Token
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token").ToString());
            #endregion

            var request = _httpClient.DeleteAsync($"https://localhost:7115/api/Situations/{id}").Result;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            HttpClient _httpClient = new HttpClient();
            #region User Token
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token").ToString());
            #endregion

            var request = _httpClient.GetAsync($"https://localhost:7115/api/Situations/{id}").Result;
            var result = JsonConvert.DeserializeObject<Situation>(request.Content.ReadAsStringAsync().Result);
            return View(result);
        }

        [HttpPost]
        public IActionResult Update(Situation situation)
        {
            HttpClient _httpClient = new HttpClient();
            #region User Token
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token").ToString());
            #endregion

            var status = JsonConvert.SerializeObject(situation);

            StringContent content = new StringContent(status, Encoding.UTF8, "application/json");
            var request = _httpClient.PutAsync("https://localhost:7115/api/Situations", content).Result;
            return RedirectToAction("Index");
        }
    }
}

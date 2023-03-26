using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Lab.Net.MVC.Models;
using System.Net.Http.Headers;

namespace Lab.Net.MVC.Controllers
{
    public class RickAndMortyController : Controller
    {
        // GET: RickAndMorty
        
        public async Task<ActionResult> Index(int page = 1)
        {
            string baseUrl = "https://rickandmortyapi.com/api/character";
            string charactersEndpoint = $"character?page={page}";

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseUrl);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await httpClient.GetAsync(charactersEndpoint);
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    var characterResponse = JsonConvert.DeserializeObject<CharacterResponse>(responseString);
                    foreach (var character in characterResponse.Results)
                    {
                        character.SetImageUrl();
                    }
                    ViewBag.CurrentPage = page;
                    ViewBag.NextPageUrl = characterResponse.Info.Next;
                    ViewBag.PrevPageUrl = characterResponse.Info.Prev;

                    return View(characterResponse);
                }
                else
                {
                    return View("Error");
                }
            }
        }
    }
}
using ClinicPro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;

namespace ClinicPro.Controllers
{
    public class DoctorController : Controller
    {

        public readonly IHttpClientFactory _httpClientFactory;
        public DoctorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            var httpClient = _httpClientFactory.CreateClient("ClinicProApi");
            var httpResponse = httpClient.GetAsync("api/Doctor").Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                var display = httpResponse.Content.ReadAsAsync<List<DoctorViewModel>>().Result;
                return View(display);
            }
            else
            {
                return View("Error");
            }

        }

     

        public IActionResult Create(DoctorViewModel doctor)
        {
            if (ModelState.IsValid)
            {
                var httpClient = _httpClientFactory.CreateClient("ClinicProApi");
                var httpResponse = httpClient.PostAsJsonAsync("api/Doctor", doctor).Result;

                if (httpResponse.IsSuccessStatusCode)
                {
                    // Patient created successfully
                    return RedirectToAction("Index");
                }
                else
                {
                    // Error occurred while creating the patient
                    return View("Error");
                }
            }
            return View("Create", doctor);
        }

        public IActionResult Details(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("ClinicProApi");
            var httpResponse = httpClient.GetAsync($"api/Doctor/{id}").Result;
            if (httpResponse.IsSuccessStatusCode)
            {
                var doctor = httpResponse.Content.ReadAsAsync<DoctorViewModel>().Result;
                return View(doctor);
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult Delete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("ClinicProApi");
            var httpResponse = httpClient.DeleteAsync($"api/Doctor/{id}").Result;

            if (httpResponse.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }


   

     


        public IActionResult Edit(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("ClinicProApi");
            var httpResponse = httpClient.GetAsync($"api/Doctor/{id}").Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                var doctor = httpResponse.Content.ReadAsAsync<DoctorViewModel>().Result;
                return View(doctor);
            }
            else
            {
                return View("Error");
            }
        }


        [HttpPost]
        public IActionResult Edit(DoctorViewModel doctor)
        {
            if (ModelState.IsValid)
            {
                var httpClient = _httpClientFactory.CreateClient("ClinicProApi");
                var httpResponse = httpClient.PutAsJsonAsync("api/Doctor", doctor).Result;

                if (httpResponse.IsSuccessStatusCode)
                {
                    // Patient updated successfully
                    return RedirectToAction("Index");
                }
                else
                {
                    // Error occurred while updating the patient
                    return View("Error");
                }
            }

            return View("Edit", doctor);
        }

    }
}

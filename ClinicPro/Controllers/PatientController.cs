using ClinicPro.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicPro.Controllers
{
    public class PatientController : Controller
    {
        public readonly IHttpClientFactory _httpClientFactory;
        public PatientController(IHttpClientFactory httpClientFactory) {
        _httpClientFactory = httpClientFactory;
    }

        
        public IActionResult Index() {
            var httpClient = _httpClientFactory.CreateClient("ClinicProApi");
            var httpResponse =  httpClient.GetAsync("api/Patient").Result;
        
            if (httpResponse.IsSuccessStatusCode) {
                var display = httpResponse.Content.ReadAsAsync<List<PatientViewModel>>().Result;           
                return View(display);
            } else
            {
                return View("Error");
            }         
        }

        public IActionResult Create(PatientViewModel patient)
        {
            if (ModelState.IsValid)
            {
                var httpClient = _httpClientFactory.CreateClient("ClinicProApi");
                var httpResponse = httpClient.PostAsJsonAsync("api/Patient/CreatePatient", patient).Result;

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
           return View("Create", patient);
        }



        public IActionResult Details(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("ClinicProApi");
            var httpResponse = httpClient.GetAsync($"api/Patient/{id}").Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                var patient = httpResponse.Content.ReadAsAsync<PatientViewModel>().Result;
                return View(patient);
            }
            else
            {
                return View("Error");
            }
        }


      
        public IActionResult Delete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("ClinicProApi");
            var httpResponse = httpClient.DeleteAsync($"api/Patient/{id}").Result;

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
            var httpResponse = httpClient.GetAsync($"api/Patient/{id}").Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                var patient = httpResponse.Content.ReadAsAsync<PatientViewModel>().Result;
                return View(patient);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult Edit(PatientViewModel patient)
        {
            if (ModelState.IsValid)
            {
                var httpClient = _httpClientFactory.CreateClient("ClinicProApi");
                var httpResponse = httpClient.PutAsJsonAsync("api/Patient", patient).Result;

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

            return View("Edit", patient);
        }

    }
}

using ClinicPro.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicPro.Controllers
{
    public class AppointmentController : Controller
    {
        public readonly IHttpClientFactory _httpClientFactory;
        public AppointmentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public IActionResult Index()
        {
            var httpClient = _httpClientFactory.CreateClient("ClinicProApi");
            var httpResponse = httpClient.GetAsync("api/Appointment").Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                var display = httpResponse.Content.ReadAsAsync<List<AppointmentViewModel>>().Result;
                return View(display);
            }
            else
            {
                return View("Error");
            }
        }



        public IActionResult Create(AppointmentViewModel department)
        {
            if (ModelState.IsValid)
            {
                var httpClient = _httpClientFactory.CreateClient("ClinicProApi");
                var httpResponse = httpClient.PostAsJsonAsync("api/Appointment", department).Result;

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
            return View("Create", department);
        }



        public IActionResult Details(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("ClinicProApi");
            var httpResponse = httpClient.GetAsync($"api/Appointment/{id}").Result;
            if (httpResponse.IsSuccessStatusCode)
            {
                var appointment = httpResponse.Content.ReadAsAsync<AppointmentViewModel>().Result;
                return View(appointment);
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult Delete(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("ClinicProApi");
            var httpResponse = httpClient.DeleteAsync($"api/Appointment/{id}").Result;

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
            var httpResponse = httpClient.GetAsync($"api/Appointment/{id}").Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                var appointment = httpResponse.Content.ReadAsAsync<AppointmentViewModel>().Result;
                return View(appointment);
            }
            else
            {
                return View("Error");
            }
        }



        [HttpPost]
        public IActionResult Edit(AppointmentViewModel appointment)
        {
            if (ModelState.IsValid)
            {
                var httpClient = _httpClientFactory.CreateClient("ClinicProApi");
                var httpResponse = httpClient.PutAsJsonAsync("api/Appointment", appointment).Result;

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

            return View("Edit", appointment);        
        }

    }
}

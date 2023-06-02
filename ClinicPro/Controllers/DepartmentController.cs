using ClinicPro.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicPro.Controllers
{
    public class DepartmentController : Controller
    {
        public readonly IHttpClientFactory _httpClientFactory;
        public DepartmentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            var httpClient = _httpClientFactory.CreateClient("ClinicProApi");
            var httpResponse = httpClient.GetAsync("api/Department").Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                var display = httpResponse.Content.ReadAsAsync<List<DepartmentViewModel>>().Result;
                return View(display);
            }
            else
            {
                return View("Error");
            }

        }



        public IActionResult Create(DepartmentViewModel department)
        {
            if (ModelState.IsValid)
            {
                var httpClient = _httpClientFactory.CreateClient("ClinicProApi");
                var httpResponse = httpClient.PostAsJsonAsync("api/Department", department).Result;

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
            var httpResponse = httpClient.GetAsync($"api/Department/{id}").Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                var doctor = httpResponse.Content.ReadAsAsync<DepartmentViewModel>().Result;
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
            var httpResponse = httpClient.DeleteAsync($"api/Department/{id}").Result;

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
            var httpResponse = httpClient.GetAsync($"api/Department/{id}").Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                var department = httpResponse.Content.ReadAsAsync<DepartmentViewModel>().Result;
                return View(department);
            }
            else
            {
                return View("Error");
            }
        }


        [HttpPost]
        public IActionResult Edit(DepartmentViewModel department)
        {
            if (ModelState.IsValid)
            {
                var httpClient = _httpClientFactory.CreateClient("ClinicProApi");
                var httpResponse = httpClient.PutAsJsonAsync("api/Department", department).Result;

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

            return View("Edit", department);
        }
    }
}

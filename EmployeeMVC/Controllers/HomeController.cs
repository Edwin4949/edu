using EmployeeMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace EmployeeMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        [HttpGet]
        public async Task <IActionResult> EmpView()
        {
            
        
        var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44331");
            List<EmployeeModel>? employee = new List<EmployeeModel>();
            HttpResponseMessage res = client.GetAsync("api/Emp/Get").Result;
            if(res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<List<EmployeeModel>>(result);

            }
            return View(employee);

        }

            public async Task<ActionResult> Post()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44331");
            List<DesignationMvc>? designationTemp = new List<DesignationMvc>();

            HttpResponseMessage res = await client.GetAsync("api/DesignationApi");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                designationTemp = JsonConvert.DeserializeObject<List<DesignationMvc>>(result);
                ViewData["designationtemp"] = designationTemp;
            }
            return View();
        }

            [HttpPost]
            public IActionResult Post(EmployeeModel empreg)
        {

            HttpClientHandler clienthandler = new HttpClientHandler();
            clienthandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslpolicyerrors) => { return true; };


            HttpClient client = new HttpClient(clienthandler);
            client.BaseAddress = new Uri("https://localhost:44331");
            var postTask = client.PostAsJsonAsync<EmployeeModel>("api/Emp/Post/", empreg);
            postTask.Wait();
            var Result = postTask.Result;
            if (Result.IsSuccessStatusCode)
            {
                return RedirectToAction("EmpView");
            }
            return View();
        }

        public async Task<IActionResult> Delete(string UserName)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44331");
            await client.DeleteAsync($"api/Emp/Delete/{UserName}");
            return RedirectToAction("EmpView");

        }

        [HttpPost]
        public async Task<IActionResult> Edit(TempData temp)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44331");
            var postTask = client.PostAsJsonAsync<TempData>("api/Emp/Edit", temp);
            postTask.Wait();
            var Result = postTask.Result;
            if (Result.IsSuccessStatusCode)
            {
                return RedirectToAction("EmpView");
            }
            return View();
        }

        public async Task<IActionResult> Edit(string username)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44331");
            List<DesignationMvc>? designationTemp = new List<DesignationMvc>();

            HttpResponseMessage des = await client.GetAsync("api/DesignationApi");

            if (des.IsSuccessStatusCode)
            {
                var result = des.Content.ReadAsStringAsync().Result;
                designationTemp = JsonConvert.DeserializeObject<List<DesignationMvc>>(result);
                ViewData["designationtemp"] = designationTemp;
            }

            TempData employee = new TempData();
            HttpResponseMessage res = await client.GetAsync($"api/Emp/Get/{username}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<TempData>(result);
            }


            return View(employee);
        }

        public ActionResult designation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> designation(DesignationMvc designationClass)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44331");
            var postTask = client.PostAsJsonAsync<DesignationMvc>("api/DesignationApi/designation", designationClass);

            /*  var postTask = client.PostAsJsonAsync<DesignationClass>("api/Designation/Designation", designationClass)*/
            postTask.Wait();
            var Result = postTask.Result;
            if (Result.IsSuccessStatusCode)
            {
                return RedirectToAction("DashBoard", "AdminMvc");
            }
            return View();
        }

        

    }


}

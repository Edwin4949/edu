using EmployeeMVC.Models;
using Microsoft.AspNetCore.Mvc;

public class AdminMvcController : Controller
{
    public ActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(AdLogin loginDetails)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://localhost:44331");
        var postTask = client.PostAsJsonAsync("api/LoginApi/login", loginDetails);
        postTask.Wait();
        var Result = postTask.Result;
        if (!Result.IsSuccessStatusCode)
        {
            return BadRequest("User wrong");
        }
        return RedirectToAction("DashBoard", "AdminMvc");
    }


    public IActionResult Register(AdLogin user2)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://localhost:44331");
        var postTask = client.PostAsJsonAsync<AdLogin>("api/LoginApi/register", user2);
        postTask.Wait();
        var Result = postTask.Result;
        if (Result.IsSuccessStatusCode)
        {
            return RedirectToAction("Login", "AdminMvc");
        }
        return View();
    }
    public ActionResult DashBoard()
    {
        return View();
    }
    public ActionResult Logout()
    {
        return RedirectToAction("Login", "AdminMvc");
    }
}




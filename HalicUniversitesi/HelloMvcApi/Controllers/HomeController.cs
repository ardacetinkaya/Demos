using Microsoft.AspNetCore.Mvc;

namespace HelloMvcApi
{

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index() => View();

    }
}
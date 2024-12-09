using Microsoft.AspNetCore.Mvc;

namespace Deployee.Controllers
{
    public class Department : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

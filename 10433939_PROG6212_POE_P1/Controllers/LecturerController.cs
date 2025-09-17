using Microsoft.AspNetCore.Mvc;

namespace _10433939_PROG6212_POE_P1.Controllers
{
    public class LecturerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SubmitClaim()
        {
            return View();
        }
        public IActionResult ViewStatus(int id)
        {
            return View();
        }
    }
}

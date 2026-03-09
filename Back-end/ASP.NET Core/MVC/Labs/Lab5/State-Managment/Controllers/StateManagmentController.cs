using Microsoft.AspNetCore.Mvc;

namespace State_Managment.Controllers
{
    public class StateManagmentController : Controller
    {
        public IActionResult SetCookie()
        {
            CookieOptions cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30), // specify cookie is Persistent Cookies or Non-Persistent Cookies
                Secure = true,
                HttpOnly = true,
            };

            //create or modify cookies from server to browser
            Response.Cookies.Append("Message", "Honda by3ml cookies gamda", cookieOptions); // must pass cookiesOptions to make Persistent

            return Content($"Cookie saved!!");
        }

        public IActionResult GetCookie()
        {
            var msg = Request.Cookies["Message"];
            return Content(msg);
        }

        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("Message", "Honda 3ando session .Net 6 sa3at");
            return Content("Session added Succefully");
        }
        public IActionResult GetSession(string key)
        {
            var msg = HttpContext.Session.GetString("Message");
            return Content(msg);
        }
    }
}

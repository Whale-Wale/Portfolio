using Microsoft.AspNetCore.Mvc;

namespace PortfolioWebApp.Areas.Admin.Controllers
{
    // Kế thừa BaseAdminController để bắt buộc đăng nhập
    [Area("Admin")]
    public class HomeController : BaseAdminController
    {
        // GET: /Admin/Home/Index
        public IActionResult Index()
        {
            // Lấy tên admin từ Session để chào mừng
            ViewData["Username"] = HttpContext.Session.GetString("Username");
            return View();
        }
    }
}
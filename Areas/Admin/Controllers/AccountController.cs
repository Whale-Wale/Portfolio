using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioWebApp.Data; // Cần using DbContext
using PortfolioWebApp.Models; // Cần using Model User (từ thư mục gốc)
using System.Threading.Tasks;

namespace PortfolioWebApp.Areas.Admin.Controllers
{
    [Area("Admin")] // Quan trọng: Báo cho Controller biết nó thuộc Area "Admin"
    public class AccountController : Controller
    {
        private readonly PortfolioDbContext _context;

        public AccountController(PortfolioDbContext context)
        {
            _context = context; // Nhận DbContext qua Dependency Injection
        }

        // GET: /Admin/Account/Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // LƯU Ý: Đây là cách kiểm tra mật khẩu RẤT MẤT AN TOÀN, chỉ dùng để demo.
            // Thực tế bạn PHẢI HASH MẬT KHẨU (dùng BCrypt.Net.BCrypt.Verify)
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user != null && user.PasswordHash == password) // Tạm thời so sánh plain text
            {
                // Đăng nhập thành công, lưu Username vào Session
                HttpContext.Session.SetString("Username", user.Username);

                // Chuyển hướng đến trang quản lý chính (chúng ta sẽ tạo sau)
                return RedirectToAction("Index", "Home");
            }

            ViewData["Error"] = "Tài khoản hoặc mật khẩu không đúng";
            return View(); // Trả về trang Login với thông báo lỗi
        }

        // GET: /Admin/Account/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Xóa Session
            return RedirectToAction("Login", "Account"); // Về trang đăng nhập
        }

        // TẠM THỜI: Tạo tài khoản admin lần đầu tiên
        // Bạn chỉ nên chạy 1 LẦN DUY NHẤT, sau đó XÓA action này đi
        public async Task<IActionResult> CreateAdminAccount()
        {
            if (await _context.Users.AnyAsync(u => u.Username == "admin"))
            {
                return Content("Tài khoản admin đã tồn tại!");
            }

            var adminUser = new User
            {
                Username = "admin",
                PasswordHash = "12345" // Mật khẩu demo, PHẢI THAY BẰNG HASH
            };

            _context.Users.Add(adminUser);
            await _context.SaveChangesAsync();
            return Content("Tài khoản admin (admin/12345) đã được tạo thành công!");
        }
    }
}
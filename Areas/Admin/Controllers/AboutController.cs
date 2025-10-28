using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioWebApp.Data;
using PortfolioWebApp.Models;
using System.Threading.Tasks;

namespace PortfolioWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : BaseAdminController // Kế thừa BaseAdminController
    {
        private readonly PortfolioDbContext _context;

        public AboutController(PortfolioDbContext context)
        {
            _context = context;
        }

        // GET: /Admin/About/Edit
        public async Task<IActionResult> Edit()
        {
            // Tìm dòng "About" đầu tiên và duy nhất trong CSDL
            var aboutInfo = await _context.About.FirstOrDefaultAsync();

            // Nếu CSDL (bảng About) chưa có dữ liệu (chạy lần đầu tiên)
            if (aboutInfo == null)
            {
                // Tạo một đối tượng About mới, rỗng
                aboutInfo = new About();
            }

            // Gửi đối tượng (rỗng hoặc có dữ liệu) này tới View
            return View(aboutInfo);
        }

        // POST: /Admin/About/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(About aboutModel)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem đây là lần lưu đầu tiên hay là cập nhật
                if (aboutModel.Id == 0) // Id = 0 nghĩa là đối tượng mới (lần đầu)
                {
                    _context.Add(aboutModel); // Thêm mới
                }
                else
                {
                    _context.Update(aboutModel); // Cập nhật cái đã có
                }

                await _context.SaveChangesAsync(); // Lưu thay đổi vào CSDL

                // Gửi thông báo thành công về View
                ViewData["Success"] = "Cập nhật thông tin thành công!";

                return View(aboutModel); // Trả về View với dữ liệu vừa cập nhật
            }
            return View(aboutModel); // Nếu lỗi, hiển thị lại form với lỗi
        }
    }
}
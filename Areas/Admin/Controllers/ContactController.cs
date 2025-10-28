using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioWebApp.Data;
using PortfolioWebApp.Models;
using System.Threading.Tasks;

namespace PortfolioWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : BaseAdminController // Kế thừa BaseAdminController
    {
        private readonly PortfolioDbContext _context;

        public ContactController(PortfolioDbContext context)
        {
            _context = context;
        }

        // GET: /Admin/Contact/Edit
        public async Task<IActionResult> Edit()
        {
            // SỬA: Tìm dòng "Contact" đầu tiên và duy nhất trong CSDL
            var contactInfo = await _context.Contacts.FirstOrDefaultAsync();

            // SỬA: Nếu CSDL (bảng Contact) chưa có dữ liệu (chạy lần đầu tiên)
            if (contactInfo == null)
            {
                // SỬA: Tạo một đối tượng Contact mới, rỗng
                contactInfo = new Contact();
            }

            // SỬA: Gửi đối tượng (rỗng hoặc có dữ liệu) này tới View
            return View(contactInfo);
        }

        // POST: /Admin/Contact/Edit (Sửa comment)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Contact contactModel)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem đây là lần lưu đầu tiên hay là cập nhật
                if (contactModel.Id == 0) // Id = 0 nghĩa là đối tượng mới (lần đầu)
                {
                    _context.Add(contactModel); // Thêm mới
                }
                else
                {
                    _context.Update(contactModel); // Cập nhật cái đã có
                }

                await _context.SaveChangesAsync(); // Lưu thay đổi vào CSDL

                // Gửi thông báo thành công về View
                ViewData["Success"] = "Cập nhật thông tin thành công!";

                return View(contactModel); // Trả về View với dữ liệu vừa cập nhật
            }
            return View(contactModel); // Nếu lỗi, hiển thị lại form với lỗi
        }
    }
}
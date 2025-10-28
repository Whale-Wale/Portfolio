using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PortfolioWebApp.Areas.Admin.Controllers
{
    [Area("Admin")] // Đảm bảo tất cả Controller kế thừa đều thuộc Area Admin
    public class BaseAdminController : Controller
    {
        // Hàm này sẽ tự động chạy TRƯỚC BẤT KỲ Action nào trong Controller con
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Kiểm tra xem Session "Username" có tồn tại không
            if (HttpContext.Session.GetString("Username") == null)
            {
                // Nếu không có Session, tức là chưa đăng nhập
                // Chuyển hướng về trang Login
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Account" },
                        { "action", "Login" },
                        { "area", "Admin" } // Quan trọng: Phải chỉ đúng Area
                    });
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
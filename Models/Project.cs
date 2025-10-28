using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioWebApp.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tên Dự Án")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [StringLength(255)]
        [Url]
        [Display(Name = "Link Ảnh Minh Họa")]
        public string ImageUrl { get; set; }

        [StringLength(255)]
        [Url]
        [Display(Name = "Link Demo Dự Án")]
        public string ProjectUrl { get; set; }

        [StringLength(255)]
        [Url]
        [Display(Name = "Link Mã Nguồn (GitHub)")]
        public string GithubUrl { get; set; }

        // Bổ sung
        [StringLength(200)]
        [Display(Name = "Các công nghệ sử dụng (cách nhau bởi dấu phẩy)")]
        public string Technologies { get; set; } // Ví dụ: ".NET 8, React, SQL"

        [DataType(DataType.Date)]
        [Display(Name = "Ngày Hoàn Thành")]
        public DateTime ProjectDate { get; set; }

        [Display(Name = "Dự án nổi bật?")]
        public bool IsFeatured { get; set; } // Dùng để ghim dự án lên đầu
    }
}
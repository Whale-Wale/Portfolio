using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioWebApp.Models
{
    public class About
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [StringLength(100)]
        [Display(Name = "Họ và Tên")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập chức danh")]
        [StringLength(100)]
        [Display(Name = "Chức danh")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mô tả")]
        [DataType(DataType.MultilineText)] // Giúp hiển thị ô textarea lớn ở trang admin
        [Display(Name = "Mô tả bản thân")]
        public string Description { get; set; }

        [StringLength(255)]
        [Display(Name = "Link Ảnh Đại Diện")]
        [Url]
        public string ImageUrl { get; set; }

        [StringLength(255)]
        [Display(Name = "Link File CV")]
        [Url]
        public string CVUrl { get; set; }

        // Bổ sung các link mạng xã hội
        [StringLength(255)]
        [Display(Name = "Link LinkedIn")]
        [Url]
        public string LinkedInUrl { get; set; }

        [StringLength(255)]
        [Display(Name = "Link GitHub")]
        [Url]
        public string GithubUrl { get; set; }
    }
}
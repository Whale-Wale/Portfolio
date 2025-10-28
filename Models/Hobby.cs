using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioWebApp.Models
{
    public class Hobby
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tên Sở Thích")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Lớp Icon (ví dụ: fa-solid fa-book)")]
        public string IconClass { get; set; }
    }
}
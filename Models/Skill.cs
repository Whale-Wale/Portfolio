using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioWebApp.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tên Kỹ Năng")]
        public string Name { get; set; }

        [Range(1, 100, ErrorMessage = "Giá trị phải từ 1 đến 100")]
        [Display(Name = "Mức độ (%)")]
        public int Percentage { get; set; }

        [Required]
        [Display(Name = "Loại Kỹ Năng")]
        public SkillType Type { get; set; } // Sử dụng enum
    }
}
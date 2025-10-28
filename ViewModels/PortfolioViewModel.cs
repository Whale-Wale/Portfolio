using PortfolioWebApp.Models;
using System.Collections.Generic;

namespace PortfolioWebApp.ViewModels
{
    public class PortfolioViewModel
    {
        public About? About { get; set; }
        public List<Skill> Skills { get; set; } = new();
        public List<Hobby> Hobbies { get; set; } = new();
        public List<Project> Projects { get; set; } = new();
        public Contact? Contact { get; set; }
    }
}

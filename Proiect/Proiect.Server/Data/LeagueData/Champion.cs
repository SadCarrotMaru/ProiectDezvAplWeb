using Proiect.Models.Base;

namespace Proiect.Models.LeagueData    /// model 1
{
    public class Champion: BaseEntity
    {
        public string? Name { get; set; }

        public string? Role { get; set; }

        public string? Race { get; set; }

        public string? SplashArt_URL { get; set; }

        public Guid? IconID { get; set; }

        // relation 
        public ICollection<SelectedChampions>? SelectedChampions { get; set; }
        public Icons? Icon { get; set; }
    }
}

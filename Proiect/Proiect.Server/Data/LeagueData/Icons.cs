using Proiect.Models.Base;

namespace Proiect.Models.LeagueData
{
    public class Icons: BaseEntity   //model 5
    {
        public string? Icon_URL { get; set; }

        // relation
        public Champion? Champion { get; set; }

        public Item? Item { get; set; }
    }
}

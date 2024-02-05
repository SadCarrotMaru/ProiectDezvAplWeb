using Proiect.Models.Base;

namespace Proiect.Models.LeagueData       /// model 2
{
    public class SelectedChampions: BaseEntity
    {
        public Guid ChampionID { get; set; }
        // relation
        public Champion? Champion { get; set; }

        public ICollection<ModelsRelation>? ModelsRelations { get; set; }

    }
}

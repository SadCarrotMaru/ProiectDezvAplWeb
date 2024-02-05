using Proiect.Models.Base;

namespace Proiect.Models.LeagueData
{
    public class Item: BaseEntity
    {
        public string? Name { get; set; }

        public int Price { get; set; }

        public string? Description { get; set; }

        public Guid IconID { get; set; }

        // relation
        // public ICollection<Model4> Models4 {get; set;}

        public Icons? Icon { get; set; }
        public ICollection<ModelsRelation>? ModelsRelations { get; set; }
    }
}

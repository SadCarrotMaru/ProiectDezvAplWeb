namespace Proiect.Models.LeagueData
{
    public class ModelsRelation
    {
        public Guid ItemId { get; set; }
        public Item? Item { get; set; }

        public Guid SelectedChampId { get; set; }
        public SelectedChampions? SelectedChampions {get;set;}
    }
}

namespace Learn.Authenticate.Entity.Entities
{
    public class Category : BaseTreeEntity<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

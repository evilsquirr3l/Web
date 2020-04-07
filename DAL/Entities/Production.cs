namespace DAL.Entities
{
    public class Production : BaseEntity
    {
        public string Name { get; set; }

        public int RadiodetailId { get; set; }

        public Radiodetail Radiodetail { get; set; }

        public int CategoryId { get; set; }
        
        public Category Category { get; set; }

    }
}
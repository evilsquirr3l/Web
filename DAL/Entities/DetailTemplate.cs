namespace DAL.Entities
{
    public class DetailTemplate : BaseEntity
    {
        public int InputRadiodetailId { get; set; }

        public Radiodetail InputRadiodetail { get; set; }
        
        public int OutputRadiodetailId { get; set; }

        public Radiodetail OutputRadiodetail { get; set; }

        public int ProductionId { get; set; }

        public Production Production { get; set; }
    }
}
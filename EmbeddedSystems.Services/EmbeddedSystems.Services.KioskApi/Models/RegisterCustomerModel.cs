namespace EmbeddedSystems.Services.KioskApi.Models
{
    public class RegisterCustomerModel
    {
        public string Name { get; set; }

        public string Mobile { get; set; }

        public string Address { get; set; }

        public int LanguageId { get; set; }

        public int KnowledgeLevelId { get; set; }
    }
}
namespace RegistracijosPozymiaiWebApi.Models
{
    public class DropDownOption
    {
        public int Id { get; set; }

        public int FeatureId { get; set; }

        public Feature Feature { get; set; }

        public string Text { get; set; }
    }
}

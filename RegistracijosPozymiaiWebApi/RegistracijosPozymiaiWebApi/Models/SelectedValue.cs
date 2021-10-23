namespace RegistracijosPozymiaiWebApi.Models
{
    public class SelectedValue
    {
        public int FormId { get; set; }

        public int FeatureId { get; set; }

        public Feature Feature { get; set; }

        public int DropDownOptionId { get; set; }

        public DropDownOption DropDownOption { get; set; }
    }
}

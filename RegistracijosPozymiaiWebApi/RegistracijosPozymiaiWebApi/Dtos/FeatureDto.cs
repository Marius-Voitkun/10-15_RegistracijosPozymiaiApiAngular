using System.Collections.Generic;

namespace RegistracijosPozymiaiWebApi.Dtos
{
    public class FeatureDto
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public List<DropDownOptionDto> DropDownOptions { get; set; }
    }
}

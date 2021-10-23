using System.Collections.Generic;

namespace RegistracijosPozymiaiWebApi.Models
{
    public class Feature
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public List<DropDownOption> DropDownOptions { get; set; }
    }
}

using System.Collections.Generic;

namespace RegistracijosPozymiaiWebApi.Dtos
{
    public class FormValuesDto
    {
        public int Id { get; set; }

        // Feature id, selected option id
        public Dictionary<int, int> SelectedValues { get; set; }
    }
}

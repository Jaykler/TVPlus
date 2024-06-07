

using System.ComponentModel.DataAnnotations;

namespace TVPlus.Application.Models.Serie
{
    public class SerieModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}



using System.ComponentModel.DataAnnotations;

namespace TVPlus.Application.Models.Productora
{
    public class ProductoraModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de la productora es requerida")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

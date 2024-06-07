using TVPlus.Domain.Core;

namespace TVPlus.Domain.Entities
{
    public class Serie: BaseEntity
    {
        public string? ImagenPortada {  get; set; }
        public string? VideoLink { get; set; }
        public int ProductoraId { get; set; }
        public int GeneroId { get; set; }
        public Productora? Productora { get; set; }

        public ICollection<Genero>? Generos { get; set; }

    }
}

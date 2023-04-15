using Livraria.Enums;

namespace Livraria.Models
{
    public class livroModel
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? DataPublic { get; set; }
        public string? Editora { get; set; }
        public string? NumISBN { get; set; }
        public LivroClassif LivroClassif { get; set; }
        public int? AutorId { get; set; }
        public virtual AutorModel? Autor { get; set; }

    }
}

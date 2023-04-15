using Livraria.Models;

namespace Livraria.Repositorio.Interfaces
{
    public interface ILivroRepositorio
    {
        Task<List<livroModel>> BuscarTodosLivros();
        Task<livroModel> BuscarParId(int id);
        Task<livroModel> Adicionar(livroModel livro);
        Task<livroModel> Atualizar(livroModel livro, int id);
        Task<bool> Apagar(int id);
    }
}

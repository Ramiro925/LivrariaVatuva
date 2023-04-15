using Livraria.Models;

namespace Livraria.Repositorio.Interfaces
{
    public interface IAutorRepositorio
    {
        Task<List<AutorModel>> BuscarTodosAutores();
        Task<AutorModel> BuscarParId(int id);
        Task<AutorModel> Adicionar(AutorModel autor);
        Task<AutorModel> Atualizar(AutorModel autor, int id);
        Task<bool> Apagar(int id);
    }
}

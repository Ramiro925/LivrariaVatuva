using Livraria.Data;
using Livraria.Models;
using Livraria.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Repositorio
{
    public class AutorRepositorio : IAutorRepositorio
    {
        private readonly SistemaTarefasDBContext _dbContext;
        public AutorRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext) 
        {
            _dbContext = sistemaTarefasDBContext;
        }
        public async Task<AutorModel> BuscarParId(int id)
        {
            return await _dbContext.Autor.FirstOrDefaultAsync(a => a.Id == id);
        }
        public  async Task<List<AutorModel>> BuscarTodosAutores()
        {
            return await _dbContext.Autor.ToListAsync();
        }
        public  async Task<AutorModel> Adicionar(AutorModel autor)
        {
            await _dbContext.Autor.AddAsync(autor);
            await _dbContext.SaveChangesAsync();

            return autor;
        }
        public async Task<AutorModel> Atualizar(AutorModel autor, int id)
        {
            AutorModel autorParId = await BuscarParId(id);

            if (autorParId == null)
            {
                throw new Exception($"Autor: {id} não encontrado no sistema.");
            }

            autorParId.Nome = autor.Nome;
            autorParId.Biografia = autor.Biografia;
            autorParId.Star = autor.Star;

            _dbContext.Autor.Update(autorParId);
            await _dbContext.SaveChangesAsync();

            return autorParId;
        }
        public async Task<bool> Apagar(int id)
        {
            AutorModel autorParId = await BuscarParId(id);

            if (autorParId == null)
            {
                throw new Exception($"Autor para o ID: {id} não encontrado no sistema.");
            }
            _dbContext.Autor.Remove(autorParId);
             await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}

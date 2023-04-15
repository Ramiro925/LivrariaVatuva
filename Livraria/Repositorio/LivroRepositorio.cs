using Livraria.Data;
using Livraria.Models;
using Livraria.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Repositorio
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly SistemaTarefasDBContext _dbContext;
        public LivroRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext) 
        {
            _dbContext = sistemaTarefasDBContext;
        }
        public async Task<livroModel> BuscarParId(int id)
        {
            return await _dbContext.Livro
                .Include(a => a.Autor)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
        public  async Task<List<livroModel>> BuscarTodosLivros()
        {
            return await _dbContext.Livro
                .Include(a => a.Autor)
                .ToListAsync();
        }
        public  async Task<livroModel> Adicionar(livroModel livro)
        {
            await _dbContext.Livro.AddAsync(livro);
            await _dbContext.SaveChangesAsync();
            return livro;
        }
        public async Task<livroModel> Atualizar(livroModel livro, int id)
        {
            livroModel livroParId = await BuscarParId(id);

            if (livroParId == null)
            {
                throw new Exception($"Livro: {id} não encontrado no sistema.");
            }

            livroParId.Titulo = livro.Titulo;
            livroParId.DataPublic = livro.DataPublic;
            livroParId.Editora = livro.Editora;
            livroParId.NumISBN = livro.NumISBN;
            livroParId.LivroClassif = livro.LivroClassif;
            livroParId.AutorId = livro.AutorId;

            _dbContext.Livro.Update(livroParId);
            await _dbContext.SaveChangesAsync();

            return livroParId;
        }
        public async Task<bool> Apagar(int id)
        {
            livroModel livroParId = await BuscarParId(id);

            if (livroParId == null)
            {
                throw new Exception($"Livro: {id} não encontrado no sistema.");
            }
            _dbContext.Livro.Remove(livroParId);
             await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}

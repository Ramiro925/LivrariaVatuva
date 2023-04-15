using Livraria.Models;
using Livraria.Repositorio;
using Livraria.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public LivroController(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<livroModel>>> ListarTodos()
        {
            List<livroModel> livros = await _livroRepositorio.BuscarTodosLivros();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<livroModel>>> BuscarParId(int id)
        {
            livroModel livros = await _livroRepositorio.BuscarParId(id);
            return Ok(livros);
        }

        [HttpPost]
        public async Task<ActionResult<livroModel>> Cadastrar([FromBody] livroModel livroModel)
        {
            livroModel livro = await _livroRepositorio.Adicionar(livroModel);
            return Ok(livro);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<livroModel>> Atualizar([FromBody] livroModel livroModel, int id)
        {
            livroModel.Id = id;
            livroModel autor = await _livroRepositorio.Atualizar(livroModel, id);
            return Ok(autor);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<livroModel>> Apagar(int id)
        {
            bool apagado = await _livroRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}

using Livraria.Models;
using Livraria.Repositorio;
using Livraria.Repositorio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepositorio _autorRepositorio;

        public  AutorController(IAutorRepositorio autorRepositorio)
        {
            _autorRepositorio = autorRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<AutorModel>>> BuscarTodosAutores()
        {
            List<AutorModel> autores = await _autorRepositorio.BuscarTodosAutores();
            return Ok(autores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<AutorModel>>> BuscarParId(int id)
        {
            AutorModel autores = await _autorRepositorio.BuscarParId(id);
            return Ok(autores);
        }

        [HttpPost]
        public async Task<ActionResult<AutorModel>> Cadastrar([FromBody] AutorModel autorModel)
        {
            AutorModel autor = await _autorRepositorio.Adicionar(autorModel);
            return Ok(autor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AutorModel>> Atualizar([FromBody] AutorModel autorModel, int id)
        {
            autorModel.Id = id;
            AutorModel autor = await _autorRepositorio.Atualizar(autorModel, id);
            return Ok(autor);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<AutorModel>> Apagar(int id)
        {
            bool apagado = await _autorRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}

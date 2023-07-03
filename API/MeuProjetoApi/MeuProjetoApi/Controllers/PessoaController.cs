using MeuProjetoApi.BancoDados.Repositorios;
using MeuProjetoApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MeuProjetoApi.Controllers
{
    [ApiController]
    public class PessoaController : ControllerBase
    {
        public PessoaRepositorio Repositorio = new PessoaRepositorio();

       

        [HttpGet]
        [Route("pessoa/obterTodos")]
        public IActionResult ObterTodos()
        {
            try
            {
                var todasPessoas = Repositorio.ObterTodos();
                return Ok(todasPessoas);

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpGet]
        [Route("pessoa/obterPorId/{id}")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                Pessoa pessoa = Repositorio.ObterPorId(id);
               


                if (pessoa == null)
                {
                    return NotFound("Não foi possivel encontrar a pessoa");
                }
                else
                {
                    return Ok(pessoa);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpPost]
        [Route("pessoa/adicionar")]
        public IActionResult Adicionar([FromBody] Pessoa pessoa)
        {
            try
            {
                if (pessoa == null)
                {
                    return BadRequest("Não foi possível obter a pessoa");
                }

                Repositorio.Adicionar(pessoa);

                return Created("", pessoa);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpPut]
        [Route("pessoa/atualizar")]
        public IActionResult Atualizar([FromBody] Pessoa pessoa)
        {
            try
            {
                Pessoa pessoaAtualizar = Repositorio.ObterPorId(pessoa.Id);

                if (pessoaAtualizar == null)
                {
                    return NotFound("Não foi possível encontrar a pessoa");
                }
                else
                {
                    //pessoaAtualizar.Id = 1;
                    pessoaAtualizar.Nome = pessoa.Nome;
                    pessoaAtualizar.Cpf = pessoa.Cpf;
                    pessoaAtualizar.Email = pessoa.Email;
                    pessoaAtualizar.Telefone = pessoa.Telefone;

                    Repositorio.Atualizar(pessoaAtualizar);

                    return Ok(pessoaAtualizar);

                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpDelete]
        [Route("pessoa/excluir/{id}")] //www.com/pessoa/excluir/1
        public IActionResult Excluir(int id)
        {
            try
            {
                var pessoa = Repositorio.ObterPorId(id);
                    

                if (pessoa == null)
                {
                    return NotFound("Pessoa não encontrada");
                }

                Repositorio.Excluir(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }
    }
}


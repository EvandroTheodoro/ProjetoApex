using MeuProjetoApi.BancoDados.Repositorios;
using MeuProjetoApi.Models;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinalApi.BancoDados.Repositorios;
using ProjetoFinalApi.Models;
using System.Net;

namespace ProjetoFinalApi.Controllers
{
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        public ProjetoRepositorio Repositorio = new ProjetoRepositorio();



        [HttpGet]
        [Route("projeto/obterTodos")]
        public IActionResult ObterTodos()
        {
            try
            {
                var todosProjetos = Repositorio.ObterTodos();
                return Ok(todosProjetos);

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpGet]
        [Route("projeto/obterPorId/{id}")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                Projetos projeto = Repositorio.ObterPorId(id);



                if (projeto == null)
                {
                    return NotFound("Não foi possivel encontrar o projeto");
                }
                else
                {
                    return Ok(projeto);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpPost]
        [Route("projeto/adicionar")]
        public IActionResult Adicionar([FromBody] Projetos projeto)
        {
            try
            {
                if (projeto == null)
                {
                    return BadRequest("Não foi possível obter o projeto");
                }

                Repositorio.Adicionar(projeto);

                return Created("", projeto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpPut]
        [Route("projeto/atualizar")]
        public IActionResult Atualizar([FromBody] Projetos projeto)
        {
            try
            {
                Projetos projetoAtualizar = Repositorio.ObterPorId(projeto.Id);

                if (projetoAtualizar == null)
                {
                    return NotFound("Não foi possível encontrar  pessoa");
                }
                else
                {
                    //projetoAtualizar.Id = 1;
                    projetoAtualizar.NomeCliente = projeto.NomeCliente;
                    projetoAtualizar.Tensao = projeto.Tensao;
                    projetoAtualizar.Potencia = projeto.Potencia;
                    projetoAtualizar.QntBobinas = projeto.QntBobinas;
                    projetoAtualizar.ValorProjeto = projeto.ValorProjeto;

                    Repositorio.Atualizar(projetoAtualizar);

                    return Ok(projetoAtualizar);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro na API: {ex.Message} - {ex.StackTrace}");
            }
        }

        [HttpDelete]
        [Route("projeto/excluir/{id}")] 
        public IActionResult Excluir(int id)
        {
            try
            {
                var projeto = Repositorio.ObterPorId(id);


                if (projeto == null)
                {
                    return NotFound("Projeto não encontrado");
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
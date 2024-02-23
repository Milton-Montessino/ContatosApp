using ContatosApp.API.Models;
using ContatosApp.Data.Entities;
using ContatosApp.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContatosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        /// <summary>
        /// Método para cadastro do contato na API
        /// </summary>
        #region Lançar Contato
        [HttpPost]
        public IActionResult Post(ContatosPostModel model)
        {
            try
            {
                var contato = new Contato
                {
                    Id = Guid.NewGuid(),
                    Nome = model.Nome,
                    Email = model.Email,
                    Telefone = model.Telefone,
                    DataHoraCadastro = DateTime.Now,
                    Ativo = 1
                };

                var contatoRepository = new ContatoRepository();
                contatoRepository.Insert(contato);

                //HTTP 201 - CREATED
                return StatusCode(201, new { message = "Contato cadastrado com sucesso.", contato });
            }
            catch (Exception e)
            {
                //HTTP 500 - INTERNAL SERVER ERROR
                return StatusCode(500, new { e.Message });
            }
        }
        #endregion

        #region Atualizar Contato
        [HttpPut]
        public IActionResult Put(ContatosPutModel model)
        {
            try
            {
                var contatoRepository = new ContatoRepository();
                var contato = contatoRepository.GetById(model.Id.Value);

                if(contato != null)
                {
                    contato.Nome = model.Nome;
                    contato.Email = model.Email;
                    contato.Telefone = model.Telefone;

                    contatoRepository.Update(contato);

                    return StatusCode(200, new { message = "Contato Atualizado com Sucesso! " });
                }
                else
                {
                    return StatusCode(400, new { message = "Contato não encontrado. Verifique o Id." });
                }
            }
            catch (Exception e)
            {
                //HTTP 500 - INTERNAL SERVER ERROR
                return StatusCode(500, new { e.Message });
            }
        }
        #endregion

        #region Deletar Contatos
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var contatoRepository = new ContatoRepository();
                var contato = contatoRepository.GetById(id);

                if (contato != null)
                {
                    contatoRepository.Delete(contato);
                    return StatusCode(200, new { message = "Contato excluido com sucesso! " });
                }
                else
                {
                    return StatusCode(400, new { message = "Contato não encontrado. Verifique o ID." });
                }
            }
            catch(Exception e)
            {
                //HTTP 500 - INTERNAL SERVER ERROR
                return StatusCode(500, new { e.Message });
            }
        }
        #endregion

        #region Consultar Contato
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var contatoRepository = new ContatoRepository();
                var contatos = contatoRepository.GetAll();

                return StatusCode(200, contatos);
            }
            catch (Exception e)
            {
                //HTTP 500 - INTERNAL SERVER ERROR
                return StatusCode(500, new { e.Message });
            }

        }
        #endregion

        #region Consulta por ID
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var contatoRepository = new ContatoRepository();
                var contato = contatoRepository.GetById(id);

                if (contato != null)
                {
                    return StatusCode(200, contato);
                }
                else
                {
                    return NoContent();
                }
            }
            catch(Exception e)
            {
                //HTTP 500 - INTERNAL SERVER ERROR
                return StatusCode(500, new { e.Message });
            }
        }

        #endregion
    }
}



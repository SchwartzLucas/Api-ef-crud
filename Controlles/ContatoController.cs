using Api.Context;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controlles
{
        [ApiController]
        [Route("Api/[Controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext agendaContext){
            _context = agendaContext;
        }
        // metodo de criacao de dados na database
        [HttpPost("Criar Contato")] // quando criamo enviamos algo, por isso o POST e nao GET
        public IActionResult Create(Contato contato){
            _context.Add(contato);
            _context.SaveChanges();

            return Ok(contato);
        }

        [HttpGet($"Buscar id: {id}")]
        public IActionResult ObterPorId(int id){
            
            var contato =_context.Contatos.Find(id);
            if(contato == null) return NotFound();
            return Ok(contato);
        }

        [HttpPut($"Atualizar id: {id}")]
        public IActionResult Atualizar(int id, Contato contato){

            var contatoBanco = _context.Contatos.Find(id);

            if(contatoBanco == null) return NotFound();

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);
            
        }

        [HttpDelete($"Deletar id: {id}")]
        public IActionResult Deletar(int id)
        {

            var contaBanco = _context.Contatos.Find(id);

            if (contaBanco == null) return NotFound();
            
                _context.Contatos.Remove(contaBanco);
                _context.SaveChanges();


                return NoContent();
            


        }
        [HttpGet($"Obter por nome: {nome}")]
    }
}
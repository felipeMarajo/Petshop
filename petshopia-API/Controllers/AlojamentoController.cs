using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using petshopia_API.Data;
using petshopia_API.Model;

namespace petshopia_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlojamentoController : ControllerBase
    {
        public readonly IPetshop contextAlojamento;
        public AlojamentoController(IPetshop context)
        {
            this.contextAlojamento = context;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
               var resultados = await contextAlojamento.GetAlojamentosAsync();
               return Ok(resultados); 
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);   
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id){
            try
            {
                var resultado = await contextAlojamento.GetAlojamentoPorIdAsync(id);
                if(resultado != null){
                    return Ok(resultado);
                }else{
                    return NotFound("Alojamento não encontrado");
                }
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);    
            }
        }



        [HttpGet("getPorAnimal/{id}")]
        public async Task<IActionResult> GetAlojamentoPorAnimal(int id){

            try
            {
                var resultado = await contextAlojamento.GetAlojamentoPorAnimalIdAsync(id);

                if(resultado != null){
                        return Ok(resultado);
                }else{
                    return NotFound("Não foi possível encontrar o alojamento");
                }
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message); 
            }  
        }


        [HttpGet("getPorStatus/{idAnimal}")]
        public async Task<IActionResult> GetAlojamentosStatusLivreEAnimalAsync(int idAnimal){
            try
            {
                var resultados = await contextAlojamento.GetAlojamentosStatusLivreEStatusAnimalAsync(idAnimal);
                if(resultados != null){
                    return Ok(resultados);
                }else{
                    return NotFound("Não foi possível encontrar o alojamento");
                }
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(Alojamento alojamento){
            
            try
            {
                contextAlojamento.Create(alojamento);
                if(await contextAlojamento.SaveAsync()){
                    return Ok(alojamento);
                }else{
                    return BadRequest("Ocorreu um erro ao inserir o alojamento");
                }
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message); 
            }
        }



        [HttpPut("{alojamentoId}")]
        public async Task<IActionResult> Put(int alojamentoId, Alojamento alojamento){

            try
            {
                var alojamentoBanco = await contextAlojamento.GetAlojamentoPorIdAsync(alojamentoId);
                if(alojamentoBanco ==null)
                    return NotFound("Alojamento não encontrado");

                contextAlojamento.Update(alojamento);
                if(await contextAlojamento.SaveAsync()){
                    return Ok(alojamento);
                }else{
                    return BadRequest("Erro ao atualizar o alojamento");
                }
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // [HttpDelete("{alojamentoId}")]
        // public async Task<IActionResult> delete(int alojamentoId, Alojamento alojamento){

        // }


        
    }
}
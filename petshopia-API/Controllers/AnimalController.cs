using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
    public class AnimalController : ControllerBase
    {
        private readonly IPetshop contextAnimal;

        public AnimalController(IPetshop context)
        {
            this.contextAnimal = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
               var resultados = await contextAnimal.GetAnimaisAsync();

               if(resultados.Count() > 0)
                    return Ok(resultados);
                
                return NotFound("Animais não encontrados");
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
                var resultado = await contextAnimal.GetAnimalPorIdAsync(id);

                if(resultado != null){
                    return Ok(resultado);
                }else{
                    return NotFound("Animal não encontrado");
                }
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("ultimoanimal")]
        public async Task<IActionResult> GetUltimoAnimalAdicionado(){
            
            try
            {
                Animal ultimoAnimalInserido = await contextAnimal.GetUltimoAnimalInserido();
                await atualizarAlojamentoComIds(ultimoAnimalInserido.IdAlojamento, ultimoAnimalInserido.EstadoSaudeId, ultimoAnimalInserido.AnimalId);
            
                if(await contextAnimal.SaveAsync())
                    return Ok("Alojamento atualizado"); 
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
            return BadRequest("Ocorreu um erro");
        }


        [HttpPost]
        public async Task<IActionResult> Post(Animal animal){

            try{
                contextAnimal.Create(animal);

                if(await contextAnimal.SaveAsync())
                    return Ok(animal);    

            }
            catch (System.Exception e){
                return BadRequest(e.Message);
            }
            return BadRequest("Não foi possível inseir o animal"); 
        }


        [HttpPut("{animalId}")]
        public async Task<IActionResult> Put(int animalId, Animal animal){

            try{
                var animalBanco = await contextAnimal.GetAnimalPorIdAsync(animalId);
                if(animalBanco == null)
                    return NotFound("Animal não encontrado");

                if(animalBanco.IdAlojamento != animal.IdAlojamento){
                    // Libera alojamento
                    var alojamentoAntigo = await contextAnimal.GetAlojamentoPorAnimalIdAsync(animalId);
                    alojamentoAntigo.EstadoAlojamentoId = 1;
                    alojamentoAntigo.AnimalId = null;
                    contextAnimal.Update(alojamentoAntigo);
                }

                // Ocupar Novo alojamento
               await atualizarAlojamentoComIds(animal.IdAlojamento, animal.EstadoSaudeId, animalId);
                    
                contextAnimal.Update(animal);

                if(await contextAnimal.SaveAsync()){
                    return Ok(animal);
                }else{
                    return BadRequest("Não foi possivel atualizar animal");
                }

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private async Task atualizarAlojamentoComIds(int alojamento, int estadoSaude, int animalId){
            var alojamentoNovo = await contextAnimal.GetAlojamentoPorIdAsync(alojamento);

            //(Alojamento) Livre = 1 | Ocupado = 2 | Esperando dono = 3
            //(Animal) Em tratamenot = 1 | Recuperando = 2 | Recuperado = 3
            var estadoAlojamentoNovo = (estadoSaude == 1 || estadoSaude == 2) ? 2 : 3;
            
            alojamentoNovo.EstadoAlojamentoId = estadoAlojamentoNovo;
            alojamentoNovo.AnimalId = animalId;

            contextAnimal.Update(alojamentoNovo);

        }

        

        [HttpDelete("{animalId}")]
        public async Task<IActionResult> Delete(int animalId){

            try{
                var animalBanco = await contextAnimal.GetAnimalPorIdAsync(animalId);
                if(animalBanco == null){
                    return NotFound("Animal não encontrado");
                }

                Alojamento alojamentoBanco = await contextAnimal.GetAlojamentoPorIdAsync(animalBanco.IdAlojamento);
                alojamentoBanco.AnimalId = null;
                alojamentoBanco.EstadoAlojamentoId = 1;

                var dono = animalBanco.Dono;
                contextAnimal.Delete(dono);
                contextAnimal.Update(alojamentoBanco);
                contextAnimal.Delete(animalBanco);
                
                if(await contextAnimal.SaveAsync())
                    return Ok();

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
             return BadRequest("Não foi possivel deletar o animal");
        }


        [HttpPut("updatealojamento/{id}")]
        public async Task<IActionResult> PutAlojamento(int id){

            try
            {
                Alojamento alojamentoBanco = await contextAnimal.GetAlojamentoPorIdAsync(id);

                alojamentoBanco.EstadoAlojamentoId = 1;
                alojamentoBanco.AnimalId = null;

                contextAnimal.Update(alojamentoBanco);
                if(await contextAnimal.SaveAsync())
                    return Ok("Atualizado");

                return BadRequest("Não atualizou");
            }
            catch (System.Exception e)
            {
                
                return BadRequest(e.Message);
            }
                
        }

        [HttpPut("atualizaalojamentocomids/{idAlojamento}")]
        public async Task<IActionResult> PutAlojamentoComids(int idAlojamento, int idAnimal, int idEstado){

            try
            {
                await atualizarAlojamentoComIds(idAlojamento, idEstado, idAnimal);
                
                if  (await contextAnimal.SaveAsync())
                    return Ok("Alojamento Atualizado");
                
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
            return BadRequest("Erro ao atualizar o alojamento");
        }



    }
}
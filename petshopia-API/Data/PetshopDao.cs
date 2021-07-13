using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using petshopia_API.Model;

namespace petshopia_API.Data
{
    public class PetshopDao : IPetshop
    {
       private DataContext contextPetshop {get;}
        public PetshopDao(DataContext context)
        {
            this.contextPetshop = context;
            // this.contextPetshop.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Create<E>(E entity) where E : class
        {
            contextPetshop.Add(entity);
        }

        public void Update<E>(E entity) where E : class
        {
            contextPetshop.Update(entity);
        }

        public void Delete<E>(E entity) where E : class
        {
            contextPetshop.Remove(entity);
        }

        public async Task<bool> SaveAsync()
        {
            return (await contextPetshop.SaveChangesAsync()) > 0;
        }

        public async Task<Animal[]> GetAnimaisAsync()
        {
            IQueryable<Animal> animais = contextPetshop.Animais
                                        .Include(d => d.Dono)
                                        .Include(e => e.EstadoSaude);
            animais = animais.AsNoTracking();

            // var animais = await contextPetshop.Animais
            // .Include(d => d.Dono)
            // .Include(e => e.EstadoSaude).ToArrayAsync();

            return await animais.ToArrayAsync();
        }

        public async Task<Animal> GetAnimalPorIdAsync(int id)
        {
            IQueryable<Animal> animal = contextPetshop.Animais
                                        .Include(d => d.Dono)
                                        .Include(e => e.EstadoSaude)
                                        .Where(i => i.AnimalId == id);

            animal = animal.AsNoTracking();

            // var animal = await contextPetshop.Animais
            //                 .Include(d => d.Dono)
            //                 .Include(s => s.EstadoSaude)
            //                 .FirstOrDefaultAsync(x => x.AnimalId==id);
            
            return await animal.FirstOrDefaultAsync();
        }

        public async Task<Animal> GetUltimoAnimalInserido(){
            IQueryable<Animal> idAnimal = contextPetshop.Animais
                                        .OrderBy(x => x.AnimalId);

            return await idAnimal.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Alojamento[]> GetAlojamentosAsync()
        {
            IQueryable<Alojamento> alojamentos = contextPetshop.Alojamentos
                                        .Include(s => s.EstadoAlojamento);

            // var alojamentos = await contextPetshop.Alojamentos
            //     .Include(s => s.EstadoAlojamento).ToArrayAsync();
                                
            alojamentos = alojamentos.AsNoTracking();
            return await alojamentos.ToArrayAsync();
        }

        public async Task<Alojamento> GetAlojamentoPorIdAsync(int id)
        {
            IQueryable<Alojamento> alojamento = contextPetshop.Alojamentos
                                                // .Include(s => s.EstadoAlojamento)
                                                .Where(i => i.AlojamentoId == id);

            // var alojamento = await contextPetshop.Alojamentos
            //                     .Include(s => s.EstadoAlojamento)
            //                     .FirstOrDefaultAsync(x => x.AlojamentoId == id);
            alojamento = alojamento.AsNoTracking();
            return await alojamento.FirstOrDefaultAsync();
        }

        public async Task<Alojamento[]> GetAlojamentosStatusLivreEStatusAnimalAsync(int idAnimal)
        {
            IQueryable<Alojamento> alojamentos = contextPetshop.Alojamentos
                                    .Include(s => s.EstadoAlojamento)
                                    .Where(s => s.AnimalId == idAnimal || s.EstadoAlojamentoId == 1);

            alojamentos = alojamentos.AsNoTracking();
            return await alojamentos.ToArrayAsync();
        }

        public async Task<Alojamento> GetAlojamentoPorAnimalIdAsync(int id)
        {
            IQueryable<Alojamento> alojamento = contextPetshop.Alojamentos
                                            // .Include(s => s.EstadoAlojamento)
                                            // .Include(i => i.EstadoAlojamentoId)
                                            .Where(x => x.AnimalId == id);
            // var alojamento = await contextPetshop.Alojamentos
            //                     .Include(s => s.EstadoAlojamento)
            //                     .Include(i => i.EstadoAlojamentoId)
            //                     .FirstOrDefaultAsync(x => x.AnimalId == id);
            alojamento = alojamento.AsNoTracking();
            return await alojamento.FirstOrDefaultAsync();
        }
    }
}
using System.Threading.Tasks;
using petshopia_API.Model;

namespace petshopia_API.Data
{
    public interface IPetshop
    {
          void Create<E>(E entity) where E : class;
         void Update<E>(E entity) where E : class;
         void Delete<E>(E entity) where E : class;
         Task<bool> SaveAsync();


         Task<Animal[]> GetAnimaisAsync();
         Task<Animal> GetAnimalPorIdAsync(int id);
         Task<Animal> GetUltimoAnimalInserido();
        //  Task<Animal[]> GetAnimaisPorStatusSaudeAsync(int statusSaude);
        //  Task<Animal[]> GetAnimaisPorDonoAsync(string nomeDono);


        Task<Alojamento[]> GetAlojamentosAsync();
         Task<Alojamento> GetAlojamentoPorIdAsync(int id);
         Task<Alojamento[]> GetAlojamentosStatusLivreEStatusAnimalAsync(int idAnimal);
         Task<Alojamento> GetAlojamentoPorAnimalIdAsync(int id);

    }
}
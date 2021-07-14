using System;
using System.Collections.Generic;
using System.Text;
using petshopia_API.Controllers;
using petshopia_API.Model;
using petshopia_API.Data;
using System.Threading.Tasks;

namespace petshopia_Teste
{
	class PetoshopServiceFake : IPetshop
	{

		private readonly List<Animal> _animais;
		private readonly List<Alojamento> _alojamento;

		public PetoshopServiceFake()
		{
			_animais = new List<Animal>() { 
				new Animal(){ AnimalId=1, Nome="Nome1", DonoId=1,Dono = new Dono(1, "David Guilmour", "Rua 1", "123456789"), EstadoSaudeId=1, EstadoSaude=new EstadoSaude(1, "Em Tratamento"), MotivacaoInternacao="Motivo 1", Foto="", IdAlojamento=1 },
				new Animal(){ AnimalId=2, Nome="Nome2", DonoId=2,Dono = new Dono(2, "David Guilmour", "Rua 1", "123456789"), EstadoSaudeId=1, EstadoSaude=new EstadoSaude(1, "Em Tratamento"), MotivacaoInternacao="Motivo 2", Foto="", IdAlojamento=2 },
				new Animal(){ AnimalId=3, Nome="Nome3", DonoId=3,Dono = new Dono(3, "David Guilmour", "Rua 1", "123456789"), EstadoSaudeId=1, EstadoSaude=new EstadoSaude(1, "Em Tratamento"), MotivacaoInternacao="Motivo 3", Foto="", IdAlojamento=3 },
				new Animal(){ AnimalId=4, Nome="Nome4", DonoId=4,Dono = new Dono(4, "David Guilmour", "Rua 1", "123456789"), EstadoSaudeId=1, EstadoSaude=new EstadoSaude(1, "Em Tratamento"), MotivacaoInternacao="Motivo 4", Foto="", IdAlojamento=4 },
			};

			_alojamento = new List<Alojamento>() {
				new Alojamento(){ AlojamentoId=1, AnimalId=1, EstadoAlojamentoId=1, EstadoAlojamento= new EstadoAlojamento(1, "Tratamento") },
				new Alojamento(){ AlojamentoId=1, AnimalId=1, EstadoAlojamentoId=1, EstadoAlojamento= new EstadoAlojamento(1, "Tratamento") },
				new Alojamento(){ AlojamentoId=1, AnimalId=1, EstadoAlojamentoId=1, EstadoAlojamento= new EstadoAlojamento(1, "Tratamento") },
				new Alojamento(){ AlojamentoId=1, AnimalId=1, EstadoAlojamentoId=1, EstadoAlojamento= new EstadoAlojamento(1, "Tratamento") }
			};

		}

		public void Create<E>(E entity) where E : class
		{
			throw new NotImplementedException();
		}

		public void Delete<E>(E entity) where E : class
		{
			throw new NotImplementedException();
		}

		public Task<Alojamento> GetAlojamentoPorAnimalIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Alojamento> GetAlojamentoPorIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Alojamento[]> GetAlojamentosAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Alojamento[]> GetAlojamentosStatusLivreEStatusAnimalAsync(int idAnimal)
		{
			throw new NotImplementedException();
		}

		public async Task<Animal[]> GetAnimaisAsync()
		{
			return _animais.ToArray();
		}

		public Task<Animal> GetAnimalPorIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Animal> GetUltimoAnimalInserido()
		{
			throw new NotImplementedException();
		}

		public Task<bool> SaveAsync()
		{
			throw new NotImplementedException();
		}

		public void Update<E>(E entity) where E : class
		{
			throw new NotImplementedException();
		}
	}
}

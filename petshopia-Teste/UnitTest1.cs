using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using petshopia_API.Controllers;
using petshopia_API.Model;
using petshopia_API.Data;
using Microsoft.AspNetCore.Mvc;
using System;

namespace petshopia_Teste
{
	[TestClass]
	public class UnitTest1
	{

		AnimalController _animalController;
		IPetshop _service;

		public UnitTest1()
		{
			_service = new PetoshopServiceFake();
			_animalController = new AnimalController(_service);
		}

		[TestMethod]
		public void TestGetTodosAnimais()
		{
			var resultado = _animalController.Get();
			Assert.IsNotNull(resultado);
		}

		[TestMethod]
		public void TestGetPorId()
		{
		}

		[TestMethod]
		public void TestGetUltimoAnimalAdicionado() 
		{
			var retorno = _animalController.GetUltimoAnimalAdicionado();
			Assert.IsNotNull(retorno);
		}


		public void TestCreate()
		{
		}

	}
}

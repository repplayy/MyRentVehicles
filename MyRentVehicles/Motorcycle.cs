using System;
using System.Collections.Generic;
using System.Text;

namespace MyRentVehicles.Entities
{
   public class Motorcycle : Vehicles
    {


		public int Cilindradas { get; set; }

		public Motorcycle(String marca, String modelo, int anoFabricacao, double valorAvaliadoDoBem, double valorDiaria, String placa, int cilindradas)
		{

			base.Marca = marca;
			base.Modelo = modelo;
			base.AnoFabricacao = anoFabricacao;
			base.ValorAvaliadoDoBem = valorAvaliadoDoBem;
			base.ValorDiaria = valorDiaria;
			base.Placa = placa;
			base.Tipo = 1;
			this.Cilindradas = cilindradas;

		}

	}
}

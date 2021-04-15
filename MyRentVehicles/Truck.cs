using System;
using System.Collections.Generic;
using System.Text;

namespace MyRentVehicles.Entities
{
   public class Truck : Vehicles
    {
		public int CapacidadeCarga { get; set; }

		public Truck(String marca, String modelo, int anoFabricacao, double valorAvaliadoDoBem, double valorDiaria, String placa, int capacidadeCarga)
		{
			base.Marca = marca;
			base.Modelo = modelo;
			base.AnoFabricacao = anoFabricacao;
			base.ValorAvaliadoDoBem = valorAvaliadoDoBem;
			base.ValorDiaria = valorDiaria;
			base.Placa = placa;
			base.Tipo = 4;
			this.CapacidadeCarga = capacidadeCarga;
		}
	}
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyRentVehicles.Entities
{
   public class Car : Vehicles
    {
        public int CategoriaCarro { get; set; }
       

		//contrutor para carro
		public Car(String marca, String modelo, int anoFabricacao, double valorAvaliadoDoBem, double valorDiaria, String placa, int caterigoriaCarro)
		{

			base.Marca = marca;
			base.Modelo = modelo;
			base.AnoFabricacao = anoFabricacao;
			base.ValorAvaliadoDoBem = valorAvaliadoDoBem;
			base.ValorDiaria = valorDiaria;
			base.Placa = placa;
			base.Tipo = 2;	
			this.CategoriaCarro = caterigoriaCarro;

		}

	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MyRentVehicles.Entities
{
    public class Bus : Vehicles
    {
        public int CapacidadePassageiro { get; set; }
     


		//contrutor para Onibus
		public Bus(String marca, String modelo, int anoFabricacao, double valorAvaliadoDoBem, double valorDiaria, String placa, int capacidadePassageiro)
		{
			base.Marca = marca;
			

			//(marca, modelo, anoFabricacao, valorAvaliadoDoBem, valorDiaria, placa, 3);

			this.CapacidadePassageiro = capacidadePassageiro;



		}

       


	}
}

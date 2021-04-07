using System;
using System.Collections.Generic;
using System.Text;

namespace MyRentVehicles.Entities
{
    public class Vehicles
    {

		public String Marca { get; set; }
        public String Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public String Placa { get; set; }
        public double ValorAvaliadoDoBem { get; set; }
        public double  ValorDiaria { get; set; }
        public int Tipo { get; set; }

		public Vehicles()
		{

		}

		public Vehicles(String marca, String modelo, int anoFabricacao, double valorAvaliadoDoBem, double valorDiaria, String placa, int tipo)
		{
			this.Marca = marca;
			this.Modelo = modelo;
			this.AnoFabricacao = anoFabricacao;
			this.Placa = placa;
			this.ValorDiaria = valorDiaria;
			this.ValorAvaliadoDoBem = valorAvaliadoDoBem;
			this.Tipo = tipo;
		}
		
		public double valorSeguro(int opcao)
		{
			//opcao moto
			if (opcao == 1)
			{
				return (ValorAvaliadoDoBem * 0.11) / 365.0;
			}

			//opcao carro
			if (opcao == 2)
			{
				return (ValorAvaliadoDoBem * 0.03) / 365.0;

			}
			//opcao caminhão
			if (opcao == 3)
			{
				return (ValorAvaliadoDoBem * 0.08) / 365.0;
			}
			//opcao onibus
			if (opcao == 4)
			{
				return (ValorAvaliadoDoBem * 0.20) / 365.0;

			}


			return 0;
		}

		//retorna valor do alugel 
		public double valorAluguel(int opcao, int dias)
		{

			return (ValorDiaria + valorSeguro(opcao)) * dias;

		}

		//diminui valor do bem

		public double valorDoBemDiminui(double taxa)
		{

			return ValorAvaliadoDoBem - taxa * ValorAvaliadoDoBem;

		}

		public double ValorDiariaAumenta(double taxa)
		{

			return ValorDiaria + taxa * ValorDiaria;

		}


	}
}

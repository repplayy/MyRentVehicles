using System;
using System.Collections.Generic;
using System.Text;

namespace MyRentVehicles.Entities
{
    public class Vehicles
    {

        public String Marca { get; set; }
		private String modelo;
		private int anoFabricacao;
		private String placa;
		private double valorAvaliadoDoBem;
		private double valorDiaria;
		private int tipo;

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


       
        public string Modelo { get => modelo; set => modelo = value; }
        public int AnoFabricacao { get => anoFabricacao; set => anoFabricacao = value; }
        public string Placa { get => placa; set => placa = value; }
        public double ValorAvaliadoDoBem { get => valorAvaliadoDoBem; set => valorAvaliadoDoBem = value; }
		public double ValorDiaria { get => valorDiaria; set => valorDiaria = value; }
		public int Tipo { get => tipo; set => tipo = value; }
    

		
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

			return ValorDiaria + taxa * ValorAvaliadoDoBem;

		}





	}
}

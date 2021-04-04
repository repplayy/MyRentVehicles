using System;
using System.Collections.Generic;
using MyRentVehicles.Entities;

namespace MyRentVehicles.Services
{
    public class RentalCarsService 
    {
        public List<Rent> RentRepository =  new List<Rent>();

        private double valorTotalMoto = 0;
		private double valorTotalCarro = 0;
		private double valorTotalCaminhao = 0;
		private double valorTotalOnibus = 0;
		private double valorTotalVeiculos = 0;
		private int diariaTotalMoto = 0;
		private int diariaTotalCarro = 0;
		private int diariaTotalCaminhao = 0;
		private int diariaTotalOnibus = 0;
		private int diariaTotalVeiculos = 0;


		//verifica se a placa do transporte já foi registrado como alugado
		public Rent rentedTransport(String plate)
		{
			
			foreach (Rent vehicle in RentRepository)
			{
				if (vehicle.Placa.Equals(plate))
				{ //compara se já existe a placa está registrada na lista do repositorio aluguel
					return vehicle;
				}

			}
			return null;
		}




		public bool reserveRent(String plate, int days, String cpf)
		{
			Vehicles vehicle = new Vehicles();
			Client cliente = new Client();
			Rent r = new Rent(cpf, plate, days);
			VehicleService v = new VehicleService();
			vehicle = v.searchPlate(plate);
			ClientService c = new ClientService();
			cliente = c.searchCpf(cpf);

			if (vehicle == null)
			{//condicional para placa inexistente não cadastrada no sistema
				return false;

			}
			if (cliente == null)
			{//condicional para CPF não encontrado na lista de cliente
				return false;
			}
			if (rentedTransport(plate) == null)
			{ //condicional para placa não encontrada no repositorio de aluguel



				if (vehicle is Motorcycle) {

					valorTotalMoto += v.calculateRent(plate,days);
					diariaTotalMoto += days;
				}
			else if (vehicle is Car) {
					valorTotalCarro += v.calculateRent(plate, days);
					diariaTotalCarro += days;
				}
				else if (vehicle is Bus)
				{
					valorTotalOnibus += v.calculateRent(plate, days);
					diariaTotalOnibus += days;

				}
				else if (vehicle is Truck) {
					valorTotalCaminhao += v.calculateRent(plate, days);
					diariaTotalCaminhao += days;

				}
				valorTotalVeiculos += v.calculateRent(plate, days);
				diariaTotalVeiculos += days;


				RentRepository.Add(r);
				return true;
				//se entrar na condicional o transporte é registrado no repositorio de aluguel
			}

			return false;

		}






























		/*
		 * 
		 * 
		 * 
		 * 
		 * 
		 * // metodo precisa ser revisto para adequar aos 3 tipos de testes 
	public boolean registrarDevolucao(String placa) {


		if (tansporteAlugado(placa) != null) {
			RepositorioDeAluguel.remove(tansporteAlugado(placa));
			//se entrar na condicional o transporte é removido da lista aluguel e conclui a devolução
			return true;
		}	
		return false;
	}

		 * 
		 * 
	

		 * 
	
	}//metodo consultar aluguel
		//valor da diaria é fixo
		public void consultarAluguel()
		{

			int dias;
			String placa;

			System.out.println("digite a placa do veiculo desejado\n");
			placa = input.next();
			System.out.println("digite a quantidade de dias\n");
			dias = input.nextInt();
			System.out.println("valor do aluguel: " + calcularAluguel(placa, dias));

		}

		
	public void aumentarDiaria(int tipo, double taxaAumento) {


		if(tipo==0) {
			for (Veiculo t : RepositorioDeVeiculo) {

				t.setValorDiaria(t.ValorDiariaAumenta(taxaAumento));					
			}

		}	

		//faz o depreciamento de cada veiculo acessando a classe de acordo com o tipo

		else if(tipo == 1 ) {

			for (Veiculo m : RepositorioDeVeiculo) {	
				if( m instanceof Moto) {

					m.setValorDiaria(m.ValorDiariaAumenta(taxaAumento));
				}	
			}

		}
		else if(tipo == 2 ) {




			for (Veiculo c : RepositorioDeVeiculo) {	

				if( c instanceof Carro) {

					c.setValorDiaria(c.ValorDiariaAumenta(taxaAumento));
				}	
			}


		}
		else if(tipo == 4) {

			for (Veiculo C : RepositorioDeVeiculo) {	
				if( C instanceof Caminhao) {

					C.setValorDiaria(C.ValorDiariaAumenta(taxaAumento));
				}		
			}

		}
		else if(tipo == 3) {

			for (Veiculo o : RepositorioDeVeiculo) {	

				if( o instanceof Onibus) {

					o.setValorDiaria(o.ValorDiariaAumenta(taxaAumento));
				}		
			}
		}


		else {
			System.out.println("not found\n");

		}		




	}

	//não implementado

	//fazer calculo de acordo com o tipo de veiculo 
	//pegando os carros já alugados no reposuitorio de aluguel , consultando o valor de cada carro alugado
	public double faturamentoTotal(int tipo,Date ontem,Date amanha) {

		if(tipo==0) {

			return valorTotalVeiculos;
		}		


		else if(tipo == 1 ) {


			return valorTotalMoto;
		}			


		else if(tipo == 2 ) {

			return valorTotalCarro;
		}		


		else if(tipo == 4 ) {

			return valorTotalCaminhao;
		}		

		else if(tipo == 3 ) {

			return valorTotalOnibus;
		}		


		System.out.println("not found\n");
		return 0;



	}
	//fazer todo calculo de diarias pegando no repositorio de aluguel e somando de acordo com o tipo
	public int quantidadeTotalDeDiarias(int tipo,Date ontem,Date amanha) {

		if(tipo==0) {

			return diariaTotalVeiculos;

		}	

		else if(tipo==1) {



			return diariaTotalMoto;


		}

		else if(tipo == 2 ) {



			return diariaTotalCarro;

		}

		else if(tipo == 4 ) {



			return diariaTotalCaminhao;
		}			

		else if(tipo == 3 ) {



			return diariaTotalOnibus;

		}



		System.out.println("not found\n");
		return 0;


	}













		*/
	}
}

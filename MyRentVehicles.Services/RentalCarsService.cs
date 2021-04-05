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

		//can create method that verify until what day the vehicle will be rent
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


		public bool registerRent(String plate, int days, String cpf)
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

		// metodo precisa ser revisto para adequar aos 3 tipos de testes 
		public bool registerDevolution(String plate)
		{


			if (rentedTransport(plate) != null)
			{
				RentRepository.Remove(rentedTransport(plate));
				//se entrar na condicional o transporte é removido da lista aluguel e conclui a devolução
				return true;
			}
			return false;
		}

		//add a info that gives until what date the vehicle will be rent 
		//metodo consultar aluguel
		public void consultRent()
		{
			VehicleService v = new VehicleService();
			int days;
			String plate;

            Console.WriteLine("digite a placa do veiculo desejado\n");
			plate = Console.ReadLine();
            Console.WriteLine("digite a quantidade de dias\n");
			days = Console.Read();
            Console.WriteLine($"valor do aluguel: {v.calculateRent(plate, days)}" );

		}
	
	

	//não implementado

	//fazer calculo de acordo com o tipo de veiculo 
	//pegando os carros já alugados no reposuitorio de aluguel , consultando o valor de cada carro alugado
		public double totalBiling(int tipo) 
		{

			if (tipo == 0)
			{

				return valorTotalVeiculos;
			}


			else if (tipo == 1)
			{


				return valorTotalMoto;
			}


			else if (tipo == 2)
			{

				return valorTotalCarro;
			}


			else if (tipo == 4)
			{

				return valorTotalCaminhao;
			}

			else if (tipo == 3)
			{

				return valorTotalOnibus;
			}
			else
			{
                Console.WriteLine("not found\n");
				return 0;

			}

		}

	//fazer todo calculo de diarias pegando no repositorio de aluguel e somando de acordo com o tipo
		public int totalAmountOfDaily(int tipo)
		{

			if (tipo == 0)
			{

				return diariaTotalVeiculos;

			}

			else if (tipo == 1)
			{

				return diariaTotalMoto;

			}

			else if (tipo == 2)
			{

				return diariaTotalCarro;

			}

			else if (tipo == 4)
			{

				return diariaTotalCaminhao;

			}

			else if (tipo == 3)
			{

				return diariaTotalOnibus;

			}

			else
			{
				Console.WriteLine("not found\n");
				return 0;
			}
				
		}



		
	}
}

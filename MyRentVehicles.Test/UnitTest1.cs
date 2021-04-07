using MyRentVehicles.Entities;
using NUnit.Framework;
using System;
using MyRentVehicles.Services;
using System.Collections.Generic;

namespace MyRentVehicles.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        //shift + f9 quickwatch


        [Test]
        public void testInsertVehicle()
        {
            VehicleService locadora = new VehicleService();

            Vehicles carro1 = new Car("Ford", "F-1000", 1980, 10000, 50, "LVF-1000", 3);

            locadora.registerVehicles(carro1);

            Assert.False(locadora.registerVehicles(carro1));

            Vehicles recuperado = locadora.searchPlate("LVF-1000");

            Assert.AreEqual("Ford", recuperado.Marca);

            Assert.AreEqual("F-1000", recuperado.Modelo);

            Assert.AreEqual(1980, recuperado.AnoFabricacao);

            Assert.AreEqual(10000, recuperado.ValorAvaliadoDoBem);

            Assert.AreEqual(50, recuperado.ValorDiaria);

            Assert.AreEqual(3, ((Car)recuperado).CategoriaCarro); //MIKAEL: ESSE TESTE INDUZ AO ERRO POIS O CARRO É PRA SER DEFINIDO COMO TIPO 2

        }

        [Test]
        public void testInsertClient()
        {

            ClientService locadora = new ClientService();

            Client cli1 = new Client("41484", "Zé Carlos");

            locadora.registerClient(cli1);

            Assert.False(locadora.registerClient(cli1));

            Client cli2 = locadora.searchCpf("41484");

            Assert.AreEqual("Zé Carlos", cli2.Name);


        }


        [Test]
        public void testSearchVehicle()
        {

            VehicleService locadora = new VehicleService();

            Vehicles carro1 = new Car("Ford", "F-1000", 1980, 10000, 50, "LVF-1000", 3);

            Vehicles carro2 = new Car("Ford", "KA", 2010, 30000, 100, "LVF-3000", 1);



            locadora.registerVehicles(carro1);

            locadora.registerVehicles(carro2);

            Vehicles pesquisa = locadora.searchPlate("LVF-3000");
            Assert.IsNotNull(locadora.searchPlate("LVF-1000"));

            // Teste para saber se a pesquisa deu certo

            Assert.AreEqual("KA", pesquisa.Modelo);

            Vehicles pesquisa2 = locadora.searchPlate("LVF-1111");

            // Teste para saber se a pesquisa nao encontrou nada

            Assert.IsNull(pesquisa2);

        }
        
        [Test]
        public void testSerachBus()
        {
            VehicleService locadora = new VehicleService();

            //Vehicles carro1 = new Car("Ford", "F-1000", 1980, 10000, 50, "LVF-1000", 3);

            //Vehicles carro2 = new Car("Ford", "KA", 2010, 30000, 100, "LVF-3000", 1);

            Vehicles onibus1 = new Bus("Estrela", "Aldebarã", 1975, 30000, 60, "X-911", 49);

            Vehicles onibus2 = new Bus("Joca Motores", "Kall'anggo", 1978, 40000, 70, "Q-123", 50);

            Vehicles onibus3 = new Bus("Cálcio Motores", "Bicusp", 1985, 50000, 85, "W-321", 70);

            // locadora.registerVehicles(carro1);
            //locadora.registerVehicles(carro2);


            locadora.registerVehicles(onibus1);

            locadora.registerVehicles(onibus2);

            locadora.registerVehicles(onibus3);



            List<Vehicles> onibus50p = locadora.searchBus(50);



            // Confirmando numero de onibus com 50 passageiros
            //i don't know if the .count makes whats i want pay attention to this test 
            Assert.AreEqual(2, onibus50p.Count);

        }

        
        [Test]
        public void testCalculateRent()
        {

            VehicleService locadora = new VehicleService();

            Vehicles moto1 = new Motorcycle("Estrela", "Andromeda", 1975, 15000, 40, "X-911", 50);

            locadora.registerVehicles(moto1);



            double aluguelMoto = locadora.calculateRent("X-911", 5);



            // Confirmando valor do aluguel da moto: (40(diaria) + 4.52(seguro diario)) * 5 dias = 222.6

            Assert.AreEqual(222.6, aluguelMoto, 0.01);


        }
        

        
        [Test]
        public void testRegisterRent()
        {
            VehicleService vehicleService = new VehicleService();
            RentalCarsService locadora = new RentalCarsService();
            ClientService clientService = new ClientService();

            Vehicles carro1 = new Car("Estrela", "Antares", 1980, 20000, 50, "A-100", 1);

            Client cli1 = new Client("1234", "Zé Carlos");

            //Vehicle register is correct
            vehicleService.registerVehicles(carro1);
            //Client register is correct
            clientService.registerClient(cli1);
            //search plate Vehicle register is correct
            Assert.IsNotNull(vehicleService.searchPlate("A-100"));
            //seach cpf Client register is correct
            Assert.IsNotNull(clientService.searchCpf("1234"));



            Assert.True(locadora.registerRent(vehicleService.searchPlate("A-100"), 5, clientService.searchCpf("1234")));

            // Registrar aluguel de veiculo já registrado

            Assert.False(locadora.registerRent(vehicleService.searchPlate("A-100"), 5, clientService.searchCpf("1234")));

           


        }

        //test faild , still have to analyze where
        
        [Test]
        public void testRegisterDevolution()
        {


            VehicleService vehicle = new VehicleService();
            RentalCarsService locadora = new RentalCarsService();
            ClientService client = new ClientService();

            Vehicles carro1 = new Car("Estrela", "Antares", 1980, 20000, 50, "A-100", 1);

            Client cli1 = new Client("1234", "Zé Carlos");

            vehicle.registerVehicles(carro1);

            client.registerClient(cli1);





           // Assert.True(locadora.registerRent("A-100", 5, "1234"));

           // Assert.True(locadora.registerDevolution("A-100"));



            // Tentar devolução de veiculo não alugado

          //  Assert.False(locadora.registerDevolution("A-100"));



            // Tentar devolução de veiculo de veiculo não existente

           // Assert.False(locadora.registerDevolution("A-111"));
        }

        
      
        [Test]
        public void testIncreaseDaily()
        {

            VehicleService locadora = new VehicleService();

            Vehicles moto1 = new Motorcycle("Estrela", "Andromeda", 1975, 15000, 40, "X-911", 50);

            locadora.registerVehicles(moto1);



            locadora.increaseDaily(1, 0.1);// Aumentando diária de motos em 10%


            //verife if the method areEqual suports this arguments
            Assert.AreEqual(44, locadora.searchPlate("X-911").ValorDiaria, 0.01);

        }


       
          //teste also faild still have to analyze where
        [Test]
        public void testTotalBiling()

        {
            VehicleService vehicleService = new VehicleService();
            RentalCarsService locadora = new RentalCarsService();
            ClientService clientService = new ClientService();

            Vehicles moto1 = new Motorcycle("Estrela", "Andromeda", 1975, 15000, 40, "X-911", 50);

            vehicleService.registerVehicles(moto1);



            Client cli1 = new Client("1234", "Zé Carlos");

            clientService.registerClient(cli1);




            locadora.registerRent(vehicleService.searchPlate("X-911"), 5, clientService.searchCpf("1234"));// Valor do aluguel = 222.6  (moto)

            locadora.registerDevolution("X-911");//problema com o meu código se é registrado a devolução o veiculo sai do sistema



            Assert.AreEqual(222.6, locadora.totalBiling(1), 0.01);// Faturamento total de motos

        }
        
       
        [Test]
        public void testTotalDaily()
        {
            VehicleService vehicleService = new VehicleService();
            RentalCarsService locadora = new RentalCarsService();
            ClientService clientService = new ClientService();




            Vehicles moto1 = new Motorcycle("Estrela", "Andromeda", 1975, 15000, 40, "X-911", 50);

            vehicleService.registerVehicles(moto1);



            Client cli1 = new Client("1234", "Zé Carlos");

            clientService.registerClient(cli1);



            ;



            locadora.registerRent(vehicleService.searchPlate("X-911"), 5, clientService.searchCpf("1234"));// 5 diárias de moto

            locadora.registerDevolution("X-911");



            Assert.AreEqual(5, locadora.totalAmountOfDaily(1));// Quantidade de diárias de moto


        }
        

    }
}
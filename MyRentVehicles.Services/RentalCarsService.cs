using System;
using System.Collections.Generic;
using MyRentVehicles.Entities;
using System.Linq;
using MyRentVehicles.DAO;

namespace MyRentVehicles.Services
{
    public class RentalCarsService
    {
        //this constructor is only to use in the test fase 
        public RentalCarsService()
        {
            DAORent daorent = new DAORent();


            daorent.deleteAll();
        }

        private double valorTotalMoto = 0;
        private double valorTotalCarro = 0;
        private double valorTotalCaminhao = 0;
        private double valorTotalOnibus = 0;
        private double valorTotalVeiculos = 0;


        public bool registerRent(Vehicles vehicle, int days, Client cliente)
        {

            DAORent daorent = new DAORent();
            Rent rent = new Rent(cliente.CPF, vehicle.Placa, days);

            if (daorent.recueByPlate(vehicle.Placa) == null)
            {     
                saveValueOfRentInMemory(vehicle, days);
                daorent.save(rent);
                return true;
              
            }
            else
            {
                return false;
            }
        }

        public bool registerDevolution(String plate)
        {
            DAORent daorent = new DAORent();
            DAODevolutionRent daoDevolutionRent = new DAODevolutionRent();
            if (daorent.recueByPlate(plate) != null)
            {
                daoDevolutionRent.save(daorent.recueByPlate(plate));
                daorent.deleteByPlate(plate);
                return true;
            }
            return false;
        }


        public void saveValueOfRentInMemory (Vehicles vehicle,int days)
            {
            if (vehicle is Motorcycle)
            {

                valorTotalMoto += vehicle.valorAluguel(1, days);
                valorTotalVeiculos += vehicle.valorAluguel(1, days);

            }
            else if (vehicle is Car)
            {
                valorTotalCarro += vehicle.valorAluguel(2, days);
                valorTotalVeiculos += vehicle.valorAluguel(1, days);

            }
            else if (vehicle is Bus)
            {
                valorTotalOnibus += vehicle.valorAluguel(3, days);
                valorTotalVeiculos += vehicle.valorAluguel(1, days);


            }
            else if (vehicle is Truck)
            {
                valorTotalCaminhao += vehicle.valorAluguel(4, days);
                valorTotalVeiculos += vehicle.valorAluguel(1, days);


            }
              
            }

        public double totalBiling(int tipo)
        {

            switch (tipo)
            {
                case 0:
                    return valorTotalVeiculos;
                case 1:

                    return valorTotalMoto;
                case 2:

                    return valorTotalCarro;
                case 3:

                    return valorTotalOnibus;
                case 4:

                    return valorTotalCaminhao;

                default:
                    Console.WriteLine("opcao invalida\n");
                    return 0;

            }

        }

        public int totalAmountOfDaily(String plate)
        {

            DAORent daorent = new DAORent();
            DAODevolutionRent daoDevolutionRent = new DAODevolutionRent();
            if (daorent.daysRentRecueByPlate(plate) == 0)
            {
                return daoDevolutionRent.daysRentRecueByPlate(plate);
            }
            else
            {
                return daorent.daysRentRecueByPlate(plate);
            }
            
        }

    }
}

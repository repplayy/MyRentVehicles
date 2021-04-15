using System;
using System.Collections.Generic;
using System.Text;
using MyRentVehicles.Entities;
using System.Linq;
using MyRentVehicles.DAO;

namespace MyRentVehicles.Services
{
    public class VehicleService
    {
        //this constructor is only to use in the test fase 
        public VehicleService()
        {

            DAOVehicle daovehicle = new DAOVehicle();
           daovehicle.deleteAll();

        }

        public Vehicles searchPlate(String placa)
        {
            DAOVehicle daovehicle = new DAOVehicle();
            return daovehicle.recueByPlate(placa);
        }

        public Boolean registerVehicles(Vehicles v)
        {
            DAOVehicle daovehicle = new DAOVehicle();    
            if (searchPlate(v.Placa) == null)
            {
                daovehicle.save(v);
                return true;
            }
            return false;

        }

        //retorna uma lista de motos de acordo com as cilindradas pesquisadas
        public List<Vehicles> searchMotorcycle(int displacement)
        {
            DAOVehicle daovehicle = new DAOVehicle();

            List<Vehicles> Displacement = new List<Vehicles>();
            foreach (Vehicles vehicle in daovehicle.RecueByType(1))
            {
                if (vehicle is Motorcycle)
                {
                    if (((Motorcycle)vehicle).Cilindradas >= displacement)
                    {
                        Displacement.Add(vehicle);
                    }
                }
            }
            return Displacement;

          
        }

        //return a list of car the same category
        public List<Vehicles> searchCar(int typeCar)
        {

            DAOVehicle daovehicle = new DAOVehicle();
            List<Vehicles> CarCategory = new List<Vehicles>();
            foreach (Vehicles vehicle in daovehicle.RecueByType(2))
            {
                if (vehicle is Car)
                {
                    if (((Car)vehicle).CategoriaCarro == typeCar)
                    {
                        CarCategory.Add(vehicle);
                    }
                }
            }
            return CarCategory;
      
        }


        //return a list of bus the same passanger capacity
        public List<Vehicles> searchBus(int capacity)
        {
            DAOVehicle daovehicle = new DAOVehicle();
            List<Vehicles> PassangerCapacity = new List<Vehicles>();
            foreach (Vehicles vehicle in daovehicle.RecueByType(3))
            {
                {
                    if (((Bus)vehicle).CapacidadePassageiro >= capacity)
                    {
                        PassangerCapacity.Add(vehicle);
                    }
                }
            }
            return PassangerCapacity;
        }


        //return a list of truck the same load capacity
        public List<Vehicles> searchTruck(int capacity)
        {
            DAOVehicle daovehicle = new DAOVehicle();
            List<Vehicles> loadCapacity = new List<Vehicles>();
            foreach (Vehicles vehicle in daovehicle.RecueByType(4))
            {
                if (vehicle is Truck)
                {
                    if (((Truck)vehicle).CapacidadeCarga >= capacity)
                    {
                        loadCapacity.Add(vehicle);
                    }
                }
            }
            return loadCapacity;

        }


        //return the type of vehicle
        public int typeVehicle(String placa)
        {
            DAOVehicle daovehicle = new DAOVehicle();
           return daovehicle.recueByPlate(placa) == null ? 0 : daovehicle.recueByPlate(placa).Tipo;
           
        }


        //depreciate the value of the vehicle by your type 
        public void depreciateVehicles(int tipo, double taxaDepreciacao)
        {
            DAOVehicle daovehicle = new DAOVehicle();

            switch (tipo)
            {
                case 0:

                    foreach (Vehicles vehicle in daovehicle.RescueAllVehicle())
                    {
                        daovehicle.updateValueVehiclesByPlate(vehicle.Placa, vehicle.valorDoBemDiminui(taxaDepreciacao));
                    }

                    break;
                case 1:

                    foreach (Vehicles motorcycle in daovehicle.RecueByType(tipo))
                    {
                        if (motorcycle is Motorcycle)
                        {
                            daovehicle.updateValueVehiclesByPlate(motorcycle.Placa, motorcycle.valorDoBemDiminui(taxaDepreciacao));
                        }
                    }
                    break;
                case 2:


                    foreach (Vehicles car in daovehicle.RecueByType(tipo))
                    {
                        if (car is Car)
                        {

                            daovehicle.updateValueVehiclesByPlate(car.Placa, car.valorDoBemDiminui(taxaDepreciacao));
                        }
                    }
                    break;
                case 3:

                    foreach (Vehicles bus in daovehicle.RecueByType(tipo))
                    {
                        if (bus is Bus)
                        {

                            daovehicle.updateValueVehiclesByPlate(bus.Placa, bus.valorDoBemDiminui(taxaDepreciacao));
                        }
                    }
                    break;
                case 4:

                    foreach (Vehicles truck in daovehicle.RecueByType(tipo))
                    {
                        if (truck is Truck)
                        {

                            daovehicle.updateValueVehiclesByPlate(truck.Placa, truck.valorDoBemDiminui(taxaDepreciacao));
                        }
                    }
                    break;

                default:
                    Console.WriteLine("opcao invalida\n");
                    break;

            }


        }

        public void increaseDaily(int tipo, double taxaAumento)
        {
            DAOVehicle daovehicle = new DAOVehicle();
            switch (tipo)
            {
                case 0:
                    foreach (Vehicles vehicle in daovehicle.RescueAllVehicle())
                    {
                       daovehicle.updateDailyVehiclesByPlate( vehicle.Placa ,vehicle.ValorDiariaAumenta(taxaAumento));
                    }
                    break;
                case 1:

                    foreach (Vehicles motorcycle in daovehicle.RecueByType(tipo))
                    {
                        if (motorcycle is Motorcycle)
                        {
                           daovehicle.updateDailyVehiclesByPlate (motorcycle.Placa, motorcycle.ValorDiariaAumenta(taxaAumento));
                        }
                    }
                    break;
                case 2:

                    foreach (Vehicles car in daovehicle.RecueByType(tipo))
                    {
                        if (car is Car)
                        {

                            daovehicle.updateDailyVehiclesByPlate(car.Placa, car.ValorDiariaAumenta(taxaAumento));
                        }
                    }
                    break;
                case 3:

                    foreach (Vehicles bus in daovehicle.RecueByType(tipo))
                    {
                        if (bus is Bus)
                        {

                            daovehicle.updateDailyVehiclesByPlate(bus.Placa, bus.ValorDiariaAumenta(taxaAumento));
                        }
                    }
                    break;
                case 4:

                    foreach (Vehicles truck in daovehicle.RecueByType(tipo))
                    {
                        if (truck is Truck)
                        {

                            daovehicle.updateDailyVehiclesByPlate(truck.Placa, truck.ValorDiariaAumenta(taxaAumento));
                        }
                    }
                    break;

                default:
                    Console.WriteLine("opcao invalida\n");
                    break;

            }

        }

        //calculate the valu of the rent of a vehicle 
        public double calculateRent(String plate, int days)
        {
            DAOVehicle daovehicle = new DAOVehicle();

            return daovehicle.recueByPlate(plate) == null ? 0 : 
                daovehicle.recueByPlate(plate).valorAluguel(typeVehicle(plate), days);
            
        }

    }

}


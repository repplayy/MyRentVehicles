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

        public VehicleService()
        {

            DAOVehicle daovehicle = new DAOVehicle();
            daovehicle.deleteAll();

        }
        public List<Vehicles> VehiclesRepository = new List<Vehicles>();

        //insere o clente no repositorio cliente 
        public Vehicles searchPlate(String placa)
        {
            DAOVehicle daovehicle = new DAOVehicle();
            return daovehicle.recueByPlate(placa);
        }

        public Boolean registerVehicles(Vehicles v)
        {
            DAOVehicle daovehicle = new DAOVehicle();
            Vehicles vehicle = searchPlate(v.Placa);
            if (vehicle == null)
            {
                daovehicle.save(v);
                return true;
            }
            return false;
            //chama metodo pesquisa 

        }


        //retorna uma lista de motos de acordo com as cilindradas pesquisadas
        public List<Vehicles> searchMotorcycle(int displacement)
        {
            DAOVehicle daovehicle = new DAOVehicle();

            List<Vehicles> Displacement = new List<Vehicles>();
            foreach (Vehicles motorcycle in daovehicle.RecueByType(1))
            {
                if (motorcycle is Motorcycle)
                {
                    if (((Motorcycle)motorcycle).Cilindradas >= displacement)
                    {
                        Displacement.Add(motorcycle);
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
            foreach (Vehicles car in daovehicle.RecueByType(2))
            {
                if (car is Car)
                {
                    if (((Car)car).CategoriaCarro == typeCar)
                    {
                        CarCategory.Add(car);
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
            foreach (Vehicles bus in daovehicle.RecueByType(3))
            {
                {
                    if (((Bus)bus).CapacidadePassageiro >= capacity)
                    {
                        PassangerCapacity.Add(bus);
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
            foreach (Vehicles truck in daovehicle.RecueByType(4))
            {
                if (truck is Truck)
                {
                    if (((Truck)truck).CapacidadeCarga >= capacity)
                    {
                        loadCapacity.Add(truck);
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
        //metodo pode ser melhorado 
        public void depreciateVehicles(int tipo, double taxaDepreciacao)
        {
            DAOVehicle daovehicle = new DAOVehicle();

            switch (tipo)
            {
                case 0:

                    foreach (Vehicles a in VehiclesRepository)
                    {
                        daovehicle.updateValueALLVehicles(a.valorDoBemDiminui(taxaDepreciacao));
                    }

                    break;
                case 1:

                    foreach (Vehicles m in daovehicle.RecueByType(tipo))
                    {
                        if (m is Motorcycle)
                        {
                            daovehicle.updateValueVehiclesBytype(tipo, m.valorDoBemDiminui(taxaDepreciacao));
                        }
                    }
                    break;
                case 2:


                    foreach (Vehicles c in daovehicle.RecueByType(tipo))
                    {
                        if (c is Car)
                        {

                            daovehicle.updateValueVehiclesBytype(tipo, c.valorDoBemDiminui(taxaDepreciacao));
                        }
                    }
                    break;
                case 3:

                    foreach (Vehicles b in daovehicle.RecueByType(tipo))
                    {
                        if (b is Bus)
                        {

                            daovehicle.updateValueVehiclesBytype(tipo, b.valorDoBemDiminui(taxaDepreciacao));
                        }
                    }
                    break;
                case 4:

                    foreach (Vehicles t in daovehicle.RecueByType(tipo))
                    {
                        if (t is Truck)
                        {

                            daovehicle.updateValueVehiclesBytype(tipo, t.valorDoBemDiminui(taxaDepreciacao));
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
                    foreach (Vehicles a in daovehicle.RecueByType(tipo))
                    {
                       daovehicle.updateDailyALLVehicles( a.ValorDiariaAumenta(taxaAumento));
                    }
                    break;
                case 1:

                    foreach (Vehicles m in daovehicle.RecueByType(tipo))
                    {
                        if (m is Motorcycle)
                        {
                           daovehicle.updateDailyVehiclesByType (tipo, m.ValorDiariaAumenta(taxaAumento));
                        }
                    }
                    break;
                case 2:

                    foreach (Vehicles c in daovehicle.RecueByType(tipo))
                    {
                        if (c is Car)
                        {

                            daovehicle.updateDailyVehiclesByType(tipo, c.ValorDiariaAumenta(taxaAumento));
                        }
                    }
                    break;
                case 3:

                    foreach (Vehicles b in daovehicle.RecueByType(tipo))
                    {
                        if (b is Bus)
                        {

                            daovehicle.updateDailyVehiclesByType(tipo, b.ValorDiariaAumenta(taxaAumento));
                        }
                    }
                    break;
                case 4:

                    foreach (Vehicles t in daovehicle.RecueByType(tipo))
                    {
                        if (t is Truck)
                        {

                            daovehicle.updateDailyVehiclesByType(tipo, t.ValorDiariaAumenta(taxaAumento));
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

        /*
        public double consultInsurance(int otion, String plate)
        {
            Vehicles v = new Vehicles();

            return v.valorSeguro(typeVehicle(plate));


        }
        */
    }

}


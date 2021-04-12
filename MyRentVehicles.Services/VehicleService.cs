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

        //public VehicleService()
        //{

        //    DAOVehicle daovehicle = new DAOVehicle();
        //    daovehicle.deleteAll();

        //}
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
            List<Vehicles> Displacement = new List<Vehicles>();
            foreach (Vehicles motorcycle in VehiclesRepository)
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
            List<Vehicles> CarCategory = new List<Vehicles>();
            foreach (Vehicles car in VehiclesRepository)
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
            List<Vehicles> PassangerCapacity = new List<Vehicles>();
            foreach (Vehicles bus in VehiclesRepository)
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
            List<Vehicles> loadCapacity = new List<Vehicles>();
            foreach (Vehicles truck in VehiclesRepository)
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
            foreach (Vehicles transporte in VehiclesRepository)
            {
                if (transporte.Placa.Equals(placa))
                { //compara se já existe a placa digitada na lista do repositorio
                    return transporte.Tipo;
                }
            }
            return 0;

        }


        //depreciate the value of the vehicle by your type
        //metodo pode ser melhorado 
        public void depreciateVehicles(int tipo, double taxaDepreciacao)
        {

            switch (tipo)
            {
                case 0:

                    foreach (Vehicles a in VehiclesRepository)
                    {
                        a.ValorAvaliadoDoBem = a.valorDoBemDiminui(taxaDepreciacao);
                    }
                    break;
                case 1:

                    foreach (Vehicles m in VehiclesRepository)
                    {
                        if (m is Motorcycle)
                        {
                            m.ValorAvaliadoDoBem = m.valorDoBemDiminui(taxaDepreciacao);
                        }
                    }
                    break;
                case 2:


                    foreach (Vehicles c in VehiclesRepository)
                    {
                        if (c is Car)
                        {

                            c.ValorAvaliadoDoBem = c.valorDoBemDiminui(taxaDepreciacao);
                        }
                    }
                    break;
                case 3:

                    foreach (Vehicles b in VehiclesRepository)
                    {
                        if (b is Bus)
                        {

                            b.ValorAvaliadoDoBem = b.valorDoBemDiminui(taxaDepreciacao);
                        }
                    }
                    break;
                case 4:

                    foreach (Vehicles t in VehiclesRepository)
                    {
                        if (t is Truck)
                        {

                            t.ValorAvaliadoDoBem = t.valorDoBemDiminui(taxaDepreciacao);
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

            switch (tipo)
            {
                case 0:
                    foreach (Vehicles a in VehiclesRepository)
                    {
                        a.ValorDiaria = a.ValorDiariaAumenta(taxaAumento);
                    }
                    break;
                case 1:

                    foreach (Vehicles m in VehiclesRepository)
                    {
                        if (m is Motorcycle)
                        {
                            m.ValorDiaria = m.ValorDiariaAumenta(taxaAumento);
                        }
                    }
                    break;
                case 2:

                    foreach (Vehicles c in VehiclesRepository)
                    {
                        if (c is Car)
                        {

                            c.ValorDiaria = c.ValorDiariaAumenta(taxaAumento);
                        }
                    }
                    break;
                case 3:

                    foreach (Vehicles b in VehiclesRepository)
                    {
                        if (b is Bus)
                        {

                            b.ValorDiaria = b.ValorDiariaAumenta(taxaAumento);
                        }
                    }
                    break;
                case 4:

                    foreach (Vehicles t in VehiclesRepository)
                    {
                        if (t is Truck)
                        {

                            t.ValorDiaria = t.ValorDiariaAumenta(taxaAumento);
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
            foreach (Vehicles v in VehiclesRepository)
            {
                if (v.Placa.Equals(plate))
                { //compara se já existe a placa digitada na lista do repositorio
                    return v.valorAluguel(typeVehicle(plate), days);
                }

            }
            return 0;
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


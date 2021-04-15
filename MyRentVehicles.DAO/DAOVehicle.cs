using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MyRentVehicles.Entities;

namespace MyRentVehicles.DAO
{
    public class DAOVehicle
    {
        DAOConnection connection;
        SqlCommand command;
        public String mensagem;
        SqlDataReader datareader;

        public void save(Vehicles vehicle)
        {
            int categoriaCarro = 0;
            int cargaCaminhao = 0;
            int cilindradas = 0;
            int passageiros = 0;
            connection = new DAOConnection();
            command = new SqlCommand();
            if (vehicle is Car)
            {

                categoriaCarro = ((Car)vehicle).CategoriaCarro;

            }
            if (vehicle is Motorcycle)
            {

                cilindradas = ((Motorcycle)vehicle).Cilindradas;

            }

            if (vehicle is Truck)
            {

                cargaCaminhao = ((Truck)vehicle).CapacidadeCarga;

            }

            if (vehicle is Bus)
            {

                passageiros = ((Bus)vehicle).CapacidadePassageiro;

            }
            //comando sql ---
            command.CommandText = "insert into locadora.dbo.Vehicle (placa,marca, modelo, ano,valoravaliado,valordiaria,categoriacarro,carga,cilindrada,passageiro,discriminador) " +
                "values (@placa,@marca,@modelo,@ano,@valoravaliado,@valordiaria,@categoriacarro,@carga,@cilindrada,@passageiro,@discriminador)";
            //parametros 
            command.Parameters.AddWithValue("placa", vehicle.Placa);
            command.Parameters.AddWithValue("marca", vehicle.Marca);
            command.Parameters.AddWithValue("modelo", vehicle.Modelo);
            command.Parameters.AddWithValue("ano", vehicle.AnoFabricacao);
            command.Parameters.AddWithValue("valoravaliado", vehicle.ValorAvaliadoDoBem);
            command.Parameters.AddWithValue("valordiaria", vehicle.ValorDiaria);
            command.Parameters.AddWithValue("categoriacarro", categoriaCarro);
            command.Parameters.AddWithValue("carga", cargaCaminhao);
            command.Parameters.AddWithValue("cilindrada", cilindradas);
            command.Parameters.AddWithValue("passageiro", passageiros);
            command.Parameters.AddWithValue("discriminador", vehicle.Tipo);



            try
            { //conectar com baNCO de dados
                command.Connection = connection.connect();
                //executar comandos 
                command.ExecuteNonQuery();
                //desconectar
                connection.disconnect();
                //mostrar mensagem de erro ou sucesso
                this.mensagem = "cadastraado com sucesso";
            }
            catch (SqlException)
            {

                this.mensagem = "erro ao se conectar banco de dados";
            }
            finally
            {
                connection.disconnect();

            }



        }

        public Vehicles recueByPlate(String plate)
        {
            command = new SqlCommand();
            connection = new DAOConnection();
            //comando sql ---
            command.CommandText = "select * from locadora.dbo.Vehicle where placa = @placa";
            //parametros 
            command.Parameters.AddWithValue("@placa", plate);



            try
            { //conectar com baNCO de dados
                command.Connection = connection.connect();
                //executar comandos 
                command.ExecuteNonQuery();
                datareader = command.ExecuteReader();
                if (datareader.HasRows)
                {
                    while (datareader.Read())
                    {
                        String daoplaca = (string)datareader["placa"];
                        String daomodelo = (string)datareader["modelo"];
                        String daomarca = (string)datareader["marca"];
                        int daoano = (int)datareader["ano"];
                        double daovaloravaliado = (double)datareader["valoravaliado"];
                        double daovalordiaria = (double)datareader["valordiaria"];
                        int daocategoriacarro = (int)datareader["categoriacarro"];
                        int daocarga = (int)datareader["carga"];
                        int daocilindrada = (int)datareader["cilindrada"];
                        int daopassageiro = (int)datareader["passageiro"];
                        int daodiscriminador = (int)datareader["discriminador"];

                        if (daodiscriminador == 1)
                        {
                            connection.disconnect();
                            Vehicles motorcycle = new Motorcycle(daomarca, daomodelo, daoano, daovaloravaliado, daovalordiaria, daoplaca, daocilindrada);
                            return motorcycle;

                        }
                        else if (daodiscriminador == 2)
                        {
                            connection.disconnect();
                            Vehicles car = new Car(daomarca, daomodelo, daoano, daovaloravaliado, daovalordiaria, daoplaca, daocategoriacarro);
                            return car;
                        }
                        else if (daodiscriminador == 3)
                        {
                            connection.disconnect();
                            Vehicles bus = new Bus(daomarca, daomodelo, daoano, daovaloravaliado, daovalordiaria, daoplaca, daopassageiro);
                            return bus;
                        }
                        else if (daodiscriminador == 4)
                        {
                            connection.disconnect();
                            Vehicles truck = new Truck(daomarca, daomodelo, daoano, daovaloravaliado, daovalordiaria, daoplaca, daocarga);
                            return truck;
                        }
                        else
                        {
                            connection.disconnect();

                            return null;
                        }



                    }
                }

                connection.disconnect();

                return null;
            }
            catch (SqlException)
            {
                connection.disconnect();
                this.mensagem = "erro ao se conectar banco de dados";
                return null;
            }




        }


        public List<Vehicles> RecueByType(int type)
        {
            command = new SqlCommand();
            connection = new DAOConnection();
            command.CommandText = "select * from locadora.dbo.Vehicle where discriminador = @discriminador ";
            command.Parameters.AddWithValue("discriminador", type);
            List<Vehicles> vehiclelist = new List<Vehicles>();

            try
            { 
                command.Connection = connection.connect();
                command.ExecuteNonQuery();
                datareader = command.ExecuteReader();
                if (datareader.HasRows)
                {
                    while (datareader.Read())
                    {

                        String daoplaca = (string)datareader["placa"];
                        String daomodelo = (string)datareader["modelo"];
                        String daomarca = (string)datareader["marca"];
                        int daoano = (int)datareader["ano"];
                        double daovaloravaliado = (double)datareader["valoravaliado"];
                        double daovalordiaria = (double)datareader["valordiaria"];
                        int daocategoriacarro = (int)datareader["categoriacarro"];
                        int daocarga = (int)datareader["carga"];
                        int daocilindrada = (int)datareader["cilindrada"];
                        int daopassageiro = (int)datareader["passageiro"];


                     
                        if (type == 1)
                        {
                            Vehicles motorcycle = new Motorcycle(daomarca, daomodelo, daoano, daovaloravaliado, daovalordiaria, daoplaca, daocilindrada);

                            vehiclelist.Add(motorcycle);


                        }
                        else if (type == 2)
                        {

                            Vehicles car = new Car(daomarca, daomodelo, daoano, daovaloravaliado, daovalordiaria, daoplaca, daocategoriacarro);


                            vehiclelist.Add(car);

                        }
                        else if (type == 3)
                        {

                            Vehicles bus = new Bus(daomarca, daomodelo, daoano, daovaloravaliado, daovalordiaria, daoplaca, daopassageiro);


                            vehiclelist.Add(bus);

                        }
                        else if (type == 4)
                        {
                            Vehicles truck = new Truck(daomarca, daomodelo, daoano, daovaloravaliado, daovalordiaria, daoplaca, daocarga);


                            vehiclelist.Add(truck);
                        }
                        else
                        {
                            connection.disconnect();

                            return null;
                        }



                    }
                }

                connection.disconnect();

                return vehiclelist;
            }
            catch (SqlException)
            {
                connection.disconnect();
                this.mensagem = "erro ao se conectar banco de dados";
                return null;
            }

        }



        public List<Vehicles> RescueAllVehicle()
        {
            command = new SqlCommand();
            connection = new DAOConnection();
            command.CommandText = "select * from locadora.dbo.Vehicle";
            List<Vehicles> vehiclelist = new List<Vehicles>();

            try
            {
                command.Connection = connection.connect();
                command.ExecuteNonQuery();
                datareader = command.ExecuteReader();
                if (datareader.HasRows)
                {
                    while (datareader.Read())
                    {

                        String daoplaca = (string)datareader["placa"];
                        String daomodelo = (string)datareader["modelo"];
                        String daomarca = (string)datareader["marca"];
                        int daoano = (int)datareader["ano"];
                        double daovaloravaliado = (double)datareader["valoravaliado"];
                        double daovalordiaria = (double)datareader["valordiaria"];
                        int daocategoriacarro = (int)datareader["categoriacarro"];
                        int daocarga = (int)datareader["carga"];
                        int daocilindrada = (int)datareader["cilindrada"];
                        int daopassageiro = (int)datareader["passageiro"];
                        int daodiscriminador = (int)datareader["discriminador"];



                        if (daodiscriminador == 1)
                        {
                            Vehicles motorcycle = new Motorcycle(daomarca, daomodelo, daoano, daovaloravaliado, daovalordiaria, daoplaca, daocilindrada);

                            vehiclelist.Add(motorcycle);


                        }
                        else if (daodiscriminador == 2)
                        {

                            Vehicles car = new Car(daomarca, daomodelo, daoano, daovaloravaliado, daovalordiaria, daoplaca, daocategoriacarro);


                            vehiclelist.Add(car);

                        }
                        else if (daodiscriminador == 3)
                        {

                            Vehicles bus = new Bus(daomarca, daomodelo, daoano, daovaloravaliado, daovalordiaria, daoplaca, daopassageiro);


                            vehiclelist.Add(bus);

                        }
                        else if (daodiscriminador == 4)
                        {
                            Vehicles truck = new Truck(daomarca, daomodelo, daoano, daovaloravaliado, daovalordiaria, daoplaca, daocarga);


                            vehiclelist.Add(truck);
                        }
                        else
                        {
                            connection.disconnect();

                            return null;
                        }



                    }
                }

                connection.disconnect();

                return vehiclelist;
            }
            catch (SqlException)
            {
                connection.disconnect();
                this.mensagem = "erro ao se conectar banco de dados";
                return null;
            }

        }




        public void updateValueVehiclesByPlate(String plate, double value)
        {

            command = new SqlCommand();
            connection = new DAOConnection();
            command.CommandText = "update locadora.dbo.Vehicle set valoravaliado = @valoravaliado where placa = @placa";
            command.Parameters.AddWithValue("@placa", plate);
            command.Parameters.AddWithValue("@valoravaliado", value);

            try
            { 
                command.Connection = connection.connect();
                command.ExecuteNonQuery();
                connection.disconnect();
            }
            catch (SqlException)
            {
                connection.disconnect();
                this.mensagem = "erro ao se conectar banco de dados";

            }

        }


        public void updateDailyVehiclesByPlate(String plate, double value)
        {

            command = new SqlCommand();
            connection = new DAOConnection();
            command.CommandText = "update locadora.dbo.Vehicle set valordiaria = @valordiaria where placa = @placa";
            command.Parameters.AddWithValue("@placa", plate);
            command.Parameters.AddWithValue("@valordiaria", value);

            try
            { 
                command.Connection = connection.connect();
                command.ExecuteNonQuery();
                connection.disconnect();
            }
            catch (SqlException)
            {
                connection.disconnect();
                this.mensagem = "erro ao se conectar banco de dados";

            }

        }

        public void deleteByPlate(String plate)
        {
            connection = new DAOConnection();
            command = new SqlCommand();
            command.CommandText = "delete from locadora.dbo.Vehicle where placa  = @placa";
            command.Parameters.AddWithValue("@valordiaria", plate);


            try
            { 
                command.Connection = connection.connect();
                command.ExecuteNonQuery();
                connection.disconnect();
                this.mensagem = "apagado";
            }
            catch (SqlException)
            {

                this.mensagem = "erro ao se conectar banco de dados";
            }

        }

        public void deleteAll()
        {
            connection = new DAOConnection();
            command = new SqlCommand();
            command.CommandText = "delete from locadora.dbo.Vehicle";



            try
            { 
                command.Connection = connection.connect();
                command.ExecuteNonQuery();
                connection.disconnect();
                this.mensagem = "apagado";
            }
            catch (SqlException)
            {

                this.mensagem = "erro ao se conectar banco de dados";
            }

        }


    }

}


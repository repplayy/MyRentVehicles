using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MyRentVehicles.Entities;

namespace MyRentVehicles.DAO
{
    public class DAOVehicle
    {
        Connection connection;
        SqlCommand cmd;
        public String mensagem;
        SqlDataReader dr;



        public void save(Vehicles vehicle)
        {
            int categoriaCarro = 0;
            int cargaCaminhao = 0;
            int cilindradas = 0;
            int passageiros = 0;
            connection = new Connection();
            cmd = new SqlCommand();
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
            cmd.CommandText = "insert into locadora.dbo.Vehicle (placa,marca, modelo, ano,valoravaliado,valordiaria,categoriacarro,carga,cilindrada,passageiro,discriminador) " +
                "values (@placa,@marca,@modelo,@ano,@valoravaliado,@valordiaria,@categoriacarro,@carga,@cilindrada,@passageiro,@discriminador)";
            //parametros 
            cmd.Parameters.AddWithValue("placa", vehicle.Placa);
            cmd.Parameters.AddWithValue("marca", vehicle.Marca);
            cmd.Parameters.AddWithValue("modelo", vehicle.Modelo);
            cmd.Parameters.AddWithValue("ano", vehicle.AnoFabricacao);
            cmd.Parameters.AddWithValue("valoravaliado", vehicle.ValorAvaliadoDoBem);
            cmd.Parameters.AddWithValue("valordiaria", vehicle.ValorDiaria);
            cmd.Parameters.AddWithValue("categoriacarro", categoriaCarro);
            cmd.Parameters.AddWithValue("carga", cargaCaminhao);
            cmd.Parameters.AddWithValue("cilindrada", cilindradas);
            cmd.Parameters.AddWithValue("passageiro", passageiros);
            cmd.Parameters.AddWithValue("discriminador", vehicle.Tipo);



            try
            { //conectar com baNCO de dados
                cmd.Connection = connection.connect();
                //executar comandos 
                cmd.ExecuteNonQuery();
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
            cmd = new SqlCommand();
            connection = new Connection();
            //comando sql ---
            cmd.CommandText = "select * from locadora.dbo.Vehicle where placa = @placa";
            //parametros 
            cmd.Parameters.AddWithValue("@placa", plate);



            try
            { //conectar com baNCO de dados
                cmd.Connection = connection.connect();
                //executar comandos 
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        String daoplaca = (string)dr["placa"];
                        String daomodelo = (string)dr["modelo"];
                        String daomarca = (string)dr["marca"];
                        int daoano = (int)dr["ano"];
                        double daovaloravaliado = (double)dr["valoravaliado"];
                        double daovalordiaria = (double)dr["valordiaria"];
                        int daocategoriacarro = (int)dr["categoriacarro"];
                        int daocarga = (int)dr["carga"];
                        int daocilindrada = (int)dr["cilindrada"];
                        int daopassageiro = (int)dr["passageiro"];
                        int daodiscriminador = (int)dr["discriminador"];

                        //can do by Enum remake later 
                        if (daodiscriminador == 1)
                        {
                            connection.disconnect();
                            Vehicles v = new Motorcycle(daomarca, daomodelo, daoano, daovaloravaliado, daovalordiaria, daoplaca, daocilindrada);
                            return v;

                        }
                        else if (daodiscriminador == 2)
                        {
                            connection.disconnect();
                            Vehicles v = new Car(daomarca, daomodelo, daoano, daovaloravaliado, daovalordiaria, daoplaca, daocategoriacarro);
                            return v;
                        }
                        else if (daodiscriminador == 3)
                        {
                            connection.disconnect();
                            Vehicles v = new Bus(daomarca, daomodelo, daoano, daovaloravaliado, daovalordiaria, daoplaca, daopassageiro);
                            return v;
                        }
                        else if (daodiscriminador == 4)
                        {
                            connection.disconnect();
                            Vehicles v = new Truck(daomarca, daomodelo, daoano, daovaloravaliado, daovalordiaria, daoplaca, daocarga);
                            return v;
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
            cmd = new SqlCommand();
            connection = new Connection();
            //comando sql ---
            cmd.CommandText = "select * from locadora.dbo.Vehicle where discriminador = @discriminador ";
            cmd.Parameters.AddWithValue("discriminador", type);
            List<Vehicles> vehiclelist = new List<Vehicles>();

            try
            { //conectar com baNCO de dados
                cmd.Connection = connection.connect();
                //executar comandos 
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        String daoplaca = (string)dr["placa"];
                        String daomodelo = (string)dr["modelo"];
                        String daomarca = (string)dr["marca"];
                        int daoano = (int)dr["ano"];
                        double daovaloravaliado = (double)dr["valoravaliado"];
                        double daovalordiaria = (double)dr["valordiaria"];
                        int daocategoriacarro = (int)dr["categoriacarro"];
                        int daocarga = (int)dr["carga"];
                        int daocilindrada = (int)dr["cilindrada"];
                        int daopassageiro = (int)dr["passageiro"];


                        //can do by Enum remake later 
                        if (type == 1)
                        {
                            Vehicles v = new Motorcycle(daomarca, daomodelo, daoano, daovaloravaliado, daovalordiaria, daoplaca, daocilindrada);

                            vehiclelist.Add(v);


                        }
                        else if (type == 2)
                        {

                            Vehicles v = new Car(daomarca, daomodelo, daoano, daovaloravaliado, daovalordiaria, daoplaca, daocategoriacarro);


                            vehiclelist.Add(v);

                        }
                        else if (type == 3)
                        {

                            Vehicles v = new Bus(daomarca, daomodelo, daoano, daovaloravaliado, daovalordiaria, daoplaca, daopassageiro);


                            vehiclelist.Add(v);

                        }
                        else if (type == 4)
                        {
                            Vehicles v = new Truck(daomarca, daomodelo, daoano, daovaloravaliado, daovalordiaria, daoplaca, daocarga);


                            vehiclelist.Add(v);
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

        public void updateValueVehiclesBytype(int tipo, double value)
        {

            cmd = new SqlCommand();
            connection = new Connection();
            //comando sql ---
            cmd.CommandText = "update locadora.dbo.Vehicle set valoravaliado = @valoravaliado where discriminador = @discriminador";
            //parametros 
            cmd.Parameters.AddWithValue("@discriminador", tipo);
            cmd.Parameters.AddWithValue("@valoravaliado", value);

            try
            { //conectar com baNCO de dados
                cmd.Connection = connection.connect();
                //executar comandos 
                cmd.ExecuteNonQuery();
                //close
                connection.disconnect();
            }
            catch (SqlException)
            {
                connection.disconnect();
                this.mensagem = "erro ao se conectar banco de dados";

            }

        }

        public void updateValueALLVehicles(double value)
        {

            cmd = new SqlCommand();
            connection = new Connection();
            //comando sql ---
            cmd.CommandText = "update locadora.dbo.Vehicle set valoravaliado = @valoravaliado";
            //parametros 
            cmd.Parameters.AddWithValue("@valoravaliado", value);

            try
            { //conectar com baNCO de dados
                cmd.Connection = connection.connect();
                //executar comandos 
                cmd.ExecuteNonQuery();
                //close
                connection.disconnect();
            }
            catch (SqlException)
            {
                connection.disconnect();
                this.mensagem = "erro ao se conectar banco de dados";

            }

        }

        public void updateDailyVehiclesByType(int tipo, double value)
        {

            cmd = new SqlCommand();
            connection = new Connection();
            //comando sql ---
            cmd.CommandText = "update locadora.dbo.Vehicle set valordiaria = @valordiaria where discriminador = @discriminador";
            //parametros 
            cmd.Parameters.AddWithValue("@discriminador", tipo);
            cmd.Parameters.AddWithValue("@valordiaria", value);

            try
            { //conectar com baNCO de dados
                cmd.Connection = connection.connect();
                //executar comandos 
                cmd.ExecuteNonQuery();
                //close
                connection.disconnect();
            }
            catch (SqlException)
            {
                connection.disconnect();
                this.mensagem = "erro ao se conectar banco de dados";

            }

        }
        public void updateDailyALLVehicles(double value)
        {

            cmd = new SqlCommand();
            connection = new Connection();
            //comando sql ---
            cmd.CommandText = "update locadora.dbo.Vehicle set valordiaria = @valordiaria";

            cmd.Parameters.AddWithValue("@valordiaria", value);

            try
            { //conectar com baNCO de dados
                cmd.Connection = connection.connect();
                //executar comandos 
                cmd.ExecuteNonQuery();
                //close
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
            connection = new Connection();
            cmd = new SqlCommand();
            //comando sql ---
            cmd.CommandText = "delete from locadora.dbo.Vehicle where placa  = @placa";
            cmd.Parameters.AddWithValue("@valordiaria", plate);


            try
            { //conectar com baNCO de dados
                cmd.Connection = connection.connect();
                //executar comandos 
                cmd.ExecuteNonQuery();
                //desconectar
                connection.disconnect();
                //mostrar mensagem de erro ou sucesso
                this.mensagem = "apagado";
            }
            catch (SqlException)
            {

                this.mensagem = "erro ao se conectar banco de dados";
            }

        }

        public void deleteAll()
        {
            connection = new Connection();
            cmd = new SqlCommand();
            //comando sql ---
            cmd.CommandText = "delete from locadora.dbo.Vehicle";



            try
            { //conectar com baNCO de dados
                cmd.Connection = connection.connect();
                //executar comandos 
                cmd.ExecuteNonQuery();
                //desconectar
                connection.disconnect();
                //mostrar mensagem de erro ou sucesso
                this.mensagem = "apagado";
            }
            catch (SqlException)
            {

                this.mensagem = "erro ao se conectar banco de dados";
            }

        }


    }





}


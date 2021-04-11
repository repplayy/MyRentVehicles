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



        public void save (Vehicles vehicle)
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
            cmd.CommandText = "insert into locadora.dbo.Vehicle (placa,marca, modelo, ano,valoravaliado,valordiaria,tipo,carga,cilindrada,passageiro,discriminador) " +
                "values (@placa,@marca,@modelo,@ano,@valoravaliado,@valordiaria,@tipo,@carga,@cilindrada,@passageiro,@discriminador)";
            //parametros 
            cmd.Parameters.AddWithValue("placa", vehicle.Placa);
            cmd.Parameters.AddWithValue("marca", vehicle.Marca);
            cmd.Parameters.AddWithValue("modelo", vehicle.Modelo);
            cmd.Parameters.AddWithValue("ano", vehicle.AnoFabricacao);
            cmd.Parameters.AddWithValue("valoravaliado", vehicle.ValorAvaliadoDoBem);
            cmd.Parameters.AddWithValue("valordiaria", vehicle.ValorDiaria);
            cmd.Parameters.AddWithValue("tipo", categoriaCarro);
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


    }





}


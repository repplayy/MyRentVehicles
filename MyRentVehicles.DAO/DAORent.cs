using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MyRentVehicles.Entities;


namespace MyRentVehicles.DAO
{
    public class DAORent
    {
        Connection connection;
        SqlCommand cmd;
        SqlDataReader dr;
        public String mensagem;

        public void save(Rent rent)
        {
            cmd = new SqlCommand();
            connection = new Connection();
            //comando sql ---
            cmd.CommandText = "insert into locadora.dbo.Rent(CPF,placa,dias) values (@CPF,@placa,@dias)";
            //parametros 
            cmd.Parameters.AddWithValue("CPF", rent.CPF);
            cmd.Parameters.AddWithValue("placa", rent.Placa);
            cmd.Parameters.AddWithValue("dias", rent.Dias);


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
                connection.disconnect();
                this.mensagem = "erro ao se conectar banco de dados";
            }


        }

        public Rent recueByPlate(String plate)
        {
            cmd = new SqlCommand();
            connection = new Connection();
            //comando sql ---
            cmd.CommandText = "select * from locadora.dbo.Rent where placa = @placa";
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
                        String daocpf = (string)dr["CPF"];
                        int daodias = (int)dr["dias"];
                        connection.disconnect();
                        Rent r = new Rent(daocpf, daoplaca, daodias);
                        return r;
                    }
                }
                //desconectar
                connection.disconnect();
                //mostrar mensagem de erro ou sucesso
                this.mensagem = "encontrado com sucesso";
                return null;
            }
            catch (SqlException)
            {
                connection.disconnect();
                this.mensagem = "erro ao se conectar banco de dados";
                return null;
            }




        }
        public Rent updateDiasByPlate(String plate, int day)
        {
            cmd = new SqlCommand();
            connection = new Connection();
            //comando sql ---
            cmd.CommandText = "update locadora.dbo.Rent set dias = @dias where placa = @placa";
            //parametros 
            cmd.Parameters.AddWithValue("@placa", plate);
            cmd.Parameters.AddWithValue("@dias", day);



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
                        String daocpf = (string)dr["CPF"];
                        int daodias = (int)dr["dias"];
                        connection.disconnect();
                        Rent r = new Rent(daocpf, daoplaca, daodias);
                        return r;
                    }
                }
                //desconectar
                connection.disconnect();
                //mostrar mensagem de erro ou sucesso
                this.mensagem = "encontrado com sucesso";
                return null;
            }
            catch (SqlException)
            {
                connection.disconnect();
                this.mensagem = "erro ao se conectar banco de dados";
                return null;
            }




        }

        public void deleteByPlate(String plate)
        {
            connection = new Connection();
            cmd = new SqlCommand();
            //comando sql ---
            cmd.CommandText = "delete from locadora.dbo.Rent where placa = @placa";
            cmd.Parameters.AddWithValue("placa", plate);



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
            cmd.CommandText = "delete from locadora.dbo.Rent";



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

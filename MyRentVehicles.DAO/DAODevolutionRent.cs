using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MyRentVehicles.Entities;
namespace MyRentVehicles.DAO
{
    public class DAODevolutionRent
    {
        DAOConnection connection;
        SqlCommand command;
        SqlDataReader datareader;
        public String mensagem;

        public void save(Rent rent)
        {
            command = new SqlCommand();
            connection = new DAOConnection();
            command.CommandText = "insert into locadora.dbo.DevolutionRent(CPF,placa,dias) values (@CPF,@placa,@dias)";
            command.Parameters.AddWithValue("CPF", rent.CPF);
            command.Parameters.AddWithValue("placa", rent.Placa);
            command.Parameters.AddWithValue("dias", rent.Dias);


            try
            { 
                command.Connection = connection.connect();
                command.ExecuteNonQuery();
                connection.disconnect();
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
            command = new SqlCommand();
            connection = new DAOConnection();
            command.CommandText = "select * from locadora.dbo.DevolutionRent where placa = @placa"; 
            command.Parameters.AddWithValue("@placa", plate);



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
                        String daocpf = (string)datareader["CPF"];
                        int daodias = (int)datareader["dias"];
                        connection.disconnect();
                        Rent r = new Rent(daocpf, daoplaca, daodias);
                        return r;
                    }
                }
                connection.disconnect();
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

        public int daysRentRecueByPlate(String plate)
        {
            command = new SqlCommand();
            connection = new DAOConnection();
            command.CommandText = "select * from locadora.dbo.DevolutionRent where placa = @placa";
            command.Parameters.AddWithValue("@placa", plate);



            try
            { 
                command.Connection = connection.connect();
                command.ExecuteNonQuery();
                datareader = command.ExecuteReader();
                if (datareader.HasRows)
                {
                    while (datareader.Read())
                    {

                        int daodias = (int)datareader["dias"];
                        connection.disconnect();

                        return daodias;
                    }
                }
                connection.disconnect();
                this.mensagem = "encontrado com sucesso";
                return 0;
            }
            catch (SqlException)
            {
                connection.disconnect();
                this.mensagem = "erro ao se conectar banco de dados";
                return 0;
            }




        }
        public Rent updateDiasByPlate(String plate, int day)
        {
            command = new SqlCommand();
            connection = new DAOConnection();
            command.CommandText = "update locadora.dbo.DevolutionRent set dias = @dias where placa = @placa";
            command.Parameters.AddWithValue("@placa", plate);
            command.Parameters.AddWithValue("@dias", day);



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
                        String daocpf = (string)datareader["CPF"];
                        int daodias = (int)datareader["dias"];
                        connection.disconnect();
                        Rent r = new Rent(daocpf, daoplaca, daodias);
                        return r;
                    }
                }
                connection.disconnect();
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
            connection = new DAOConnection();
            command = new SqlCommand();
            command.CommandText = "delete from locadora.dbo.DevolutionRent where placa = @placa";
            command.Parameters.AddWithValue("placa", plate);



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
            command.CommandText = "delete from locadora.dbo.Rent";



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

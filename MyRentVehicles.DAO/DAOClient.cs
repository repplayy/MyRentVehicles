using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MyRentVehicles.Entities;

namespace MyRentVehicles.DAO
{
    public class DAOClient
    {

        DAOConnection connection;
        SqlCommand command;
        SqlDataReader datareader;
        public String mensagem;

        public void save(Client client)
        {
            connection = new DAOConnection();
            command = new SqlCommand();
            command.CommandText = "insert into locadora.dbo.Client(CPF,Name) values (@CPF,@Name)";
            command.Parameters.AddWithValue("CPF", client.CPF);
            command.Parameters.AddWithValue("Name", client.Name);

            try
            { 
                command.Connection = connection.connect();
                command.ExecuteNonQuery();
                connection.disconnect();
            }
            catch (SqlException)
            {

                this.mensagem = "erro ao se conectar banco de dados";
            }

        }

        public Client rescueCPF(string cpf)
        {
            connection = new DAOConnection();
            command = new SqlCommand();
            command.CommandText = "select * from locadora.dbo.Client where CPF =  @CPF";
            command.Parameters.AddWithValue("@CPF", cpf);

            try
            { 
                command.Connection = connection.connect();
                datareader = command.ExecuteReader();
                if (datareader.HasRows)
                {
                    while (datareader.Read())
                    {
                        String daonome = (string)datareader["Name"];
                        String daocpf = (string)datareader["Name"];
                        connection.disconnect();
                        Client c = new Client(daocpf, daonome);
                        return c;
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
        public void updateNameClient(String cpf, String name)
        {
            connection = new DAOConnection();
            command = new SqlCommand();
            command.CommandText = "update  locadora.dbo.Client set Name = @Name where CPF = @CPF";
            command.Parameters.AddWithValue("CPF", cpf);
            command.Parameters.AddWithValue("Name", name);

            try
            { 
                command.Connection = connection.connect();
                command.ExecuteNonQuery();
                connection.disconnect();
                this.mensagem = "atualizado com sucesso";
            }
            catch (SqlException)
            {

                this.mensagem = "erro ao se conectar banco de dados";
            }

        }

        public void deletebyCPF(String cpf)
        {
            connection = new DAOConnection();
            command = new SqlCommand();
            command.CommandText = "delete from locadora.dbo.Client where CPF = @CPF";
            command.Parameters.AddWithValue("@CPF", cpf);

            try
            {
                command.Connection = connection.connect();
                command.ExecuteNonQuery();
                connection.disconnect();
                this.mensagem = "Client delete";
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
            command.CommandText = "delete from locadora.dbo.Client";

            try
            { 
                command.Connection = connection.connect();
                command.ExecuteNonQuery();
                connection.disconnect();
                this.mensagem = "data delete";
            }
            catch (SqlException)
            {

                this.mensagem = "erro ao se conectar banco de dados";
            }

        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MyRentVehicles.Entities;

namespace MyRentVehicles.DAO
{
    public class DAOClient
    {



        Connection connection;
        SqlCommand cmd;
        SqlDataReader dr;
        // SqlDataAdapter da;
        public String mensagem;


        public void save(Client client)
        {
            connection = new Connection();
            cmd = new SqlCommand();
            //comando sql ---
            cmd.CommandText = "insert into locadora.dbo.Client(CPF,Name) values (@CPF,@Name)";
            //parametros 
            cmd.Parameters.AddWithValue("CPF", client.CPF);
            cmd.Parameters.AddWithValue("Name", client.Name);


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


        }

        public Client rescueCPF(string cpf)
        {
            connection = new Connection();
            cmd = new SqlCommand();
            //comando sql ---
            cmd.CommandText = "select * from locadora.dbo.Client where CPF =  @CPF";
            //parametros 
            cmd.Parameters.AddWithValue("@CPF", cpf);



            try
            { //conectar com baNCO de dados
                cmd.Connection = connection.connect();
                //executar comandos 
                dr = cmd.ExecuteReader();
                //if (!dr.NextResult())
                //{
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        String daonome = (string)dr["Name"];
                        String daocpf = (string)dr["Name"];
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
            connection = new Connection();
            cmd = new SqlCommand();
            //comando sql ---
            cmd.CommandText = "update  locadora.dbo.Client set Name = @Name where CPF = @CPF";
            //parametros 
            cmd.Parameters.AddWithValue("CPF", cpf);
            cmd.Parameters.AddWithValue("Name", name);


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


        }


        public void deletebyCPF(String cpf)
        {
            connection = new Connection();
            cmd = new SqlCommand();
            //comando sql ---
            cmd.CommandText = "delete from locadora.dbo.Client where CPF = @CPF";
            cmd.Parameters.AddWithValue("@CPF", cpf);


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
            cmd.CommandText = "delete from locadora.dbo.Client";



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

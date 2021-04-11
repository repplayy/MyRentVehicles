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
        /*
       public void rescueCPF(string cpf)
       {
           connection = new Connection();
           cmd = new SqlCommand();
           //comando sql ---
           cmd.CommandText = "select * from Client where CPF =  @CPF";
           //parametros 
           cmd.Parameters.AddWithValue("CPF", cpf);
           SqlDataReader dr = cmd.ExecuteReader();


           try
           { //conectar com baNCO de dados
               cmd.Connection = connection.connect();
               //executar comandos 
               cmd.ExecuteNonQuery();
               while (dr.Read())
               {
                   String nome = dr[].ToString;
               }
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

       */
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MyRentVehicles.Entities;


namespace MyRentVehicles.DAO
{
    public  class DAORent
    {
        Connection connection;
        SqlCommand cmd;
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

                this.mensagem = "erro ao se conectar banco de dados";
            }




        }

       


      



    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MyRentVehicles.Entities;
using System.Linq;
using MyRentVehicles.DAO;

namespace MyRentVehicles.Services
{
    public class ClientService
    {
        //this constructor is only to use in the test fase 
        public ClientService()
        {
            DAOClient client = new DAOClient();
            client.deleteAll();
        }

        public Client searchCpf(String cpf)
        {
            DAOClient daoclient = new DAOClient();
            return daoclient.rescueCPF(cpf);
        }

        public Boolean registerClient(Client client)
        {
            DAOClient daoclient = new DAOClient();
            if (searchCpf(client.CPF) == null)
            {
                daoclient.save(client);
                return true;
            }
            return false;
        }
    }
}

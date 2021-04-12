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
       public ClientService()
        {
            DAOClient client = new DAOClient();
            client.deleteAll();


        }

        public List<Client> ClientRepository = new List<Client>();

        //insere o clente no repositorio cliente 
        public Client searchCpf(String cpf)
        {
            DAOClient client = new DAOClient();

            //return ClientRepository.Where(x => x.CPF == cpf)?.FirstOrDefault();
            return client.rescueCPF(cpf);
        }

        public Boolean registerClient(Client c)
        {
            DAOClient client = new DAOClient();
            Client cliente = searchCpf(c.CPF);
            if (cliente == null)
            {
                client.save(c);
                return true;
            }
            return false;
            //chama metodo pesquisa 

        }



    }
}

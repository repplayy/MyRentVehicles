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
		public List<Client> ClientRepository = new List<Client>();

        //insere o clente no repositorio cliente 
        public Client searchCpf(String cpf)
        {
           
            return ClientRepository.Where(x => x.CPF == cpf)?.FirstOrDefault();
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

using System;
using System.Collections.Generic;
using System.Text;
using MyRentVehicles.Entities;

namespace MyRentVehicles.Services
{
    class ClientService
    {
		public List<Client> ClientRepository = new List<Client>();

        //insere o clente no repositorio cliente 
        public Client searchCpf(String cpf)
        {

            foreach (Client c in ClientRepository)
            {
                if (c.CPF.Equals(cpf))
                {
                    return c;
                }
            }
            return null;
            //implementar metodo que pesquisa o codigo produto
        }

        public Boolean registerClient(Client c)
        {

            Client cliente = searchCpf(c.CPF);
            if (cliente == null)
            {
                ClientRepository.Add(c);
                return true;
            }
            return false;
            //chama metodo pesquisa 

        }



    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MyRentVehicles.Entities
{
   public class Rent 
    {
        public String CPF { get; set; }
        public String Placa { get; set; }
        public int Dias { get; set; }
       
		
		public Rent(String cpf, String placa, int dias)
		{

			this.CPF = cpf;
			this.Placa = placa;
			this.Dias = dias;

		}

	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MyRentVehicles.Entities
{
   public class Rent 
    {
        public int CPF { get; set; }
        public String Placa { get; set; }
        public int Dias { get; set; }
       
		
		Rent(int cpf, String placa, int dias)
		{

			this.CPF = cpf;
			this.Placa = placa;
			this.Dias = dias;

		}

	}
}

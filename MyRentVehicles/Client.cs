﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyRentVehicles.Entities
{
    public class Client
    {


        public String CPF { get; set; }
        public String Name { get; set; }

        public Client()
        {

        }
        public Client(String CPF, String name)
        {
            this.Name = name;
            this.CPF = CPF;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MyRentVehicles.Entities
{
    public class Bus : Vehicles
    {
        public int CapacidadePassageiro { get; set; }

        public Bus(String marca, String modelo, int anoFabricacao, double valorAvaliadoDoBem, double valorDiaria, String placa, int capacidadePassageiro)
        {
            base.Marca = marca;
            base.Modelo = modelo;
            base.AnoFabricacao = anoFabricacao;
            base.ValorAvaliadoDoBem = valorAvaliadoDoBem;
            base.ValorDiaria = valorDiaria;
            base.Placa = placa;
            base.Tipo = 3;
            this.CapacidadePassageiro = capacidadePassageiro;

        }

    }
}

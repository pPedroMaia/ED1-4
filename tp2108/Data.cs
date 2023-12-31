﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp2108
{
    internal class Data
    {
        private int dia;
        private int mes;
        private int ano;

        public Data(int dia, int mes, int ano)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }

        public void setData(int dia, int mes, int ano)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
        }

        public int Dia { get => this.dia; set => this.dia = value; }
        public int Mes { get => this.mes; set => this.mes = value; }
        public int Ano { get => this.ano; set => this.ano = value; }

        public override string ToString()
        {
            return this.dia + "/" + this.mes + "/" + this.ano;
        }
    }
}

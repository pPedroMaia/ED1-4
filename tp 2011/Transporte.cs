using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTransporte
{
    class Transporte
    {
        Veiculo veiculo;
        int qtdeTransportada;

        internal Veiculo Veiculo { get { return veiculo; } set { veiculo = value; } }
        public int QtdeTransportada { get { return qtdeTransportada; } set { qtdeTransportada = value; } }

        public Transporte(Veiculo veiculo, int quantidade)
        {
            this.veiculo = veiculo;
            this.qtdeTransportada = quantidade;
        }
    }
}

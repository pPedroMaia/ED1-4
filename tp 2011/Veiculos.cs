using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTransporte
{
    class Veiculos
    {
        public List<Veiculo> veiculos;
        public Veiculos()
        {
            this.veiculos = new List<Veiculo>();
        }

        public void incluir(Veiculo veiculo)
        {
            this.veiculos.Add(veiculo);
        }
    }
}

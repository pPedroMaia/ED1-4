using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoTransporte
{
    class Garagens
    {
        public List<Garagem> garagens;
        private bool jornadaAtiva;
        List<Transporte> listaTransporte;

        public bool JornadaAtiva { get { return jornadaAtiva; } }

        public Garagens()
        {
            this.jornadaAtiva = false;
            this.garagens = new List<Garagem>();
            listaTransporte = new List<Transporte>();
        }

        public void incluir(Garagem garagem)

        {
            if (!garagens.Contains(garagem))
                garagens.Add(garagem);
        }

        public void inciarJornada(List<Veiculo> listVei)
        {
            int x = garagens.Count() - 1;
            foreach (Veiculo vei in listVei)
            {
                x = x % garagens.Count;
                garagens[x].veiculos.Push(vei);
                x++;
            }
            jornadaAtiva = true;

        }
        public List<Transporte> encerrarJornada()
        {

            this.jornadaAtiva = false;

            return listaTransporte;

        }
    }
}

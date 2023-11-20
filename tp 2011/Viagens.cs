using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTransporte
{
    class Viagens
    {
        public List<Viagem> viagens;

        public Viagens()
        {
            this.viagens = new List<Viagem>();
        }

        public bool incluir(Viagem viagem)
        {
            this.viagens.Add(viagem);
            return true;
        }
    }
}

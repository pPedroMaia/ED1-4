using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTransporte
{
    class Viagem
    {
        static int temp = 1;
        static int Incrementar() { return temp++; }
        int id = 0;
        Garagem origem;
        Garagem destino;
        Veiculo veiculo;

        public int Id { get { return id; } set { id = value; } }
        public Garagem Origem { get { return origem; } set { origem = value; } }
        public Garagem Destino { get { return destino; } set { destino = value; } }
        public Veiculo Veiculo { get { return veiculo; } set { veiculo = value; } }

        public Viagem()
        {

        }

        public Viagem(Veiculo veiculo, Garagem origem, Garagem destino)
        {
            this.id = Incrementar();
            this.Origem = origem;
            this.Destino = destino;
            this.veiculo = veiculo;
        }

        public override bool Equals(object obj)
        {
            Viagem v = (Viagem)obj;
            return this.id.Equals(v.Id);
        }
    }
}

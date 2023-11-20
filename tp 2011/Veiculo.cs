using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoTransporte
{
    class Veiculo
    {
        static int temp = 1;
        static int Incrementar()
        {
            return temp++;
        }
        int id;
        private string placa;
        int lotacao;

        public int Lotacao { get { return lotacao; } }
        public int Id { get { return id; } set { id = value; } }
        public string Placa { get { return placa; } }

        public Veiculo(string placa, int lotacao)
        {
            this.id = Incrementar();
            this.lotacao = lotacao;
            this.placa = placa;
        }
        public override bool Equals(object obj)
        {
            Veiculo v = (Veiculo)obj;
            return this.Id.Equals(v.Id);
        }
    }
}

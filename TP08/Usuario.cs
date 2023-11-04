using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP08
{
    class Usuario
    {
        private int id;
        private string nome;
        private List<Ambiente> ambientes;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public List<Ambiente> Ambientes { get => ambientes; set => ambientes = value; }

        public Usuario()
        {
            this.id = 0;
            this.nome = "";
            this.ambientes = new List<Ambiente>();
        }

        public Usuario(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
            this.ambientes = new List<Ambiente>();
        }

        public bool concederPermissao(Ambiente ambiente)
        {
            bool permissaocondedida = false;
            bool jatempermissao = false;
            foreach(Ambiente a in ambientes)
            {
                if (a==ambiente)
                {
                    jatempermissao = true;
                }
            }
            if (jatempermissao == true)
            {
                Console.WriteLine("Usuário já tem permissão concedida no ambiente. Cancelando operação.\n");
            }
            else {
                ambientes.Add(ambiente);
                Console.WriteLine("Permissão concedida para o usuario.\n");
                permissaocondedida = true;
            }
            return permissaocondedida;
        }

        public bool revogarpermissao(Ambiente ambiente)
        {
            bool permissaorevogada = false;
            bool jatempermissao = false;
            foreach(Ambiente a in ambientes)
            {
                if (a == ambiente)
                {
                    jatempermissao = true;
                }
            }
            if (jatempermissao == false)
            {
                Console.WriteLine("Usuário já tem a permissão revogada no ambiente. Cancelando operação.\n");
            }
            else
            {
                ambientes.RemoveAt(ambientes.IndexOf(ambiente));
                Console.WriteLine("Permissão revogada para o usuário.\n");
                permissaorevogada = true;
            }
            return permissaorevogada;
        }

        public override bool Equals(object obj)
        {
            return this.id.Equals(((Usuario)obj).Id);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return this.Id+" - "+this.Nome;
        }
    }
}

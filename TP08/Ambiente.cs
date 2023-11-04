using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP08
{
    class Ambiente
    {
        private int id;
        private string nome;
        private Queue<Log> logs;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        internal Queue<Log> Logs { get => logs; set => logs = value; }

        public Ambiente()
        {
            this.id = 0;
            this.nome = "";
            this.logs = new Queue<Log>();
        }

        public Ambiente(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
            this.logs = new Queue<Log>();
        }

        public void registrarLog(Log log)
        {
            if (this.logs.Count == 100)
            {
                this.logs.Dequeue();
            }
            this.logs.Enqueue(log);
        }

        public void consultarLog(int tipoacesso)
        {
            if (tipoacesso == 0)
            {
                foreach (Log l in logs)
                {
                    if (l.TipoAcesso == false)
                    {
                        Console.WriteLine(l.ToString());
                    }
                }
            }

            if (tipoacesso == 1)
            {
                foreach (Log l in logs)
                {
                    if (l.TipoAcesso == true)
                    {
                        Console.WriteLine(l.ToString());
                    }
                }
            }

            if (tipoacesso == 2)
            {
                foreach (Log l in logs)
                {
                    Console.WriteLine(l.ToString());
                }
            }
            
        }

        public override bool Equals(object obj)
        {
            return this.id.Equals(((Ambiente)obj).Id);
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

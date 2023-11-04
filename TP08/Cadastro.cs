using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP08
{
    class Cadastro
    {
        private List<Usuario> usuarios;
        private List<Ambiente> ambientes;

        internal List<Usuario> Usuarios { get => usuarios; set => usuarios = value; }
        internal List<Ambiente> Ambientes { get => ambientes; set => ambientes = value; }

        public Cadastro()
        {
            usuarios = new List<Usuario>();
            ambientes = new List<Ambiente>();
        }

        public void adicionarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public bool removerUsuario(Usuario usuario)
        {
            bool removido = false;
            bool semusuario = false;
            foreach(Usuario u in usuarios)
            {
                if (u == usuario)
                {
                    semusuario = true;
                    Console.WriteLine("Usuário não existe no cadastro. Cancelando operação.\n");
                }
            }
            if (semusuario == false)
            {
                usuarios.RemoveAt(usuarios.IndexOf(usuario));
                removido = true;
                Console.WriteLine("Usuário removido com sucesso!\n");
            }
            return removido;
        }

        public Usuario pesquisarUsuario(Usuario usuario)
        {
            Usuario usuarioencontrado = new Usuario();
            foreach(Usuario u in usuarios)
            {
                if (u.Id.Equals(usuario.Id))
                {
                    usuarioencontrado = u;
                }
            }
            return usuarioencontrado;
        }

        public void adicionarAmbiente(Ambiente ambiente)
        {
            ambientes.Add(ambiente);
        }

        public bool removerAmbiente(Ambiente ambiente)
        {
            bool removido = false;
            bool temambiente = false;
            foreach(Ambiente a in ambientes)
            {
                if (a == ambiente)
                {
                    temambiente = true;
                }
            }
            if (temambiente == true)
            {
                ambientes.RemoveAt(ambientes.IndexOf(ambiente));
                removido = true;
                Console.WriteLine("Ambiente removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Ambiente não existe no cadastro. Cancelando operação.\n");
            }
            return removido;
        }

        public Ambiente pesquisarAmbiente(Ambiente ambiente)
        {
            Ambiente ambienteencontrado = new Ambiente();
            foreach(Ambiente a in ambientes)
            {
                if (a.Id.Equals(ambiente.Id))
                {
                    ambienteencontrado = a;
                }
            }
            return ambienteencontrado;
        }
    }
}

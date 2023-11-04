using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP08
{
    class Log
    {
        private DateTime dtAcesso;
        private Usuario usuario;
        private bool tipoAcesso;

        public DateTime DtAcesso { get => dtAcesso; set => dtAcesso = value; }
        public bool TipoAcesso { get => tipoAcesso; set => tipoAcesso = value; }
        public Usuario Usuario { get => usuario; set => usuario = value; }

        public Log()
        {
            this.dtAcesso = DateTime.MinValue;
            this.usuario = new Usuario();
            this.tipoAcesso = false;
        }

        public Log(DateTime dtAcesso, Usuario usuario, bool tipoAcesso)
        {
            this.dtAcesso = dtAcesso;
            this.usuario = usuario;
            this.tipoAcesso = tipoAcesso;
        }

        public override string ToString()
        {
            return "Data acesso: "+dtAcesso.Date+" - Usuário: "+usuario.Nome+" - Tipo acesso: "+tipoAcesso.ToString();
        }
    }
}

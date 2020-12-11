using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string UsuarioAcesso { get; set; }
        public string SenhaAcesso { get; set; }
        public string SenhaVerificacao { get; set; }
        public string Nome { get; set; }
    }

}

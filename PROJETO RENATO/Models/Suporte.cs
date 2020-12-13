using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Models
{
    public class Suporte
    {
        public int IdSuporte { get; set; }
        public string NomeDoAtendente { get; set; }
        public string TipoDeProblema { get; set; }
        public int AvaliacaoDoCliente { get; set; }

    }
}


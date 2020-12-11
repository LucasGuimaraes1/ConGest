using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Models
{
    public class Unidade
    {
        public int IdUnidade { get; set; }
        public string TipoDeUnidade { get; set; }
        public int IdMorador { get; set; }
        public int NumeroUnidade { get; set; }
        public int idCondominio { get; set; }
    }
}


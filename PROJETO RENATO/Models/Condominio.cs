using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Models
{
    public class Condominio
    {
        public int IdCondominio { get; set; }
        public string NomeCondominio { get; set; }
        public string Cnpj { get; set; }

        public string Endereco { get; set; }

        public List<Morador> Moradores { get; set; }



    }
}

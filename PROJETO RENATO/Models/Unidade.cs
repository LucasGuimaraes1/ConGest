using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Models
{
    public class Unidade
    {
        public int IdUnidade { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int? NumeroUnidade { get; set; }
        public int IdMorador { get; set; }
        public int idCondominio { get; set; }
        public int UnidadeTipoId { get; set; }
        [NotMapped]
        public string tipoUnidade { get; set; }
    }
}


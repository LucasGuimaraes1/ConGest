using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Models
{
    public class Condominio
    {
        public int IdCondominio { get; set; }

        [MinLength(4, ErrorMessage = "Mínimo de 4 caracteres")]
        [MaxLength(16, ErrorMessage = "Máximo de 16 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string NomeCondominio { get; set; }
        
        [MinLength(18, ErrorMessage = "Mínimo de 18 caracteres")]
        [MaxLength(18, ErrorMessage = "Máximo de 18 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cnpj { get; set; }

        [MinLength(4, ErrorMessage = "Mínimo de 4 caracteres")]
        [MaxLength(200, ErrorMessage = "Máximo de 200 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Endereco { get; set; }
    }
}

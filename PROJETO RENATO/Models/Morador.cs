using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Models
{
    public class Morador
    {
        public int IdMorador { get; set; }

        [MinLength(4, ErrorMessage = "Mínimo de 4 caracteres")]
        [MaxLength(32, ErrorMessage = "Máximo de 16 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [MinLength(14, ErrorMessage = "Mínimo de 14 caracteres (Verifique mascara)")]
        [MaxLength(14, ErrorMessage = "Maximo de 14 caracteres (Verifique mascara)")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string CPF { get; set; }

        [MinLength(8, ErrorMessage = "Mínimo de 4 caracteres")]
        [MaxLength(32, ErrorMessage = "Máximo de 16 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Email { get; set; }
    }
}

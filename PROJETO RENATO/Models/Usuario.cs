using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_RENATO.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [MinLength(4,ErrorMessage ="Mínimo de 4 caracteres")]
        [MaxLength(16,ErrorMessage ="Máximo de 16 caracteres")]
        [Required(ErrorMessage ="Campo Obrigatório")]
        public string UsuarioAcesso { get; set; }

        [MinLength(4, ErrorMessage = "Mínimo de 4 caracteres")]
        [MaxLength(16, ErrorMessage = "Máximo de 16 caracteres")]
        [Required(ErrorMessage ="Campo Obrigatório")]
        public string SenhaAcesso { get; set; }

        [MinLength(4, ErrorMessage = "Mínimo de 4 caracteres")]
        [MaxLength(16, ErrorMessage = "Máximo de 16 caracteres")]
        [Required(ErrorMessage ="Campo Obrigatório")]
        public string SenhaVerificacao { get; set; }

        [MinLength(4, ErrorMessage = "Mínimo de 4 caracteres")]
        [MaxLength(16, ErrorMessage = "Máximo de 16 caracteres")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }
    }

}

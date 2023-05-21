using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Exercicio01.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public string Nome { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Forneça um e-mail válido com @")]
        public string Email { get; set; }
    }
}

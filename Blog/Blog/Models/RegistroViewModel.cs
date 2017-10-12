using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class RegistroViewModel
    {
        [Required]
        [Display(Name = "Usuário")]
        public string LoginName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Senha")]
        [Display(Name = "Confirmação da senha")]
        public string ConfirmacaoSenha { get; set; }
    }
}
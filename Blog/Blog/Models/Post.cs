using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Por favor, preencha o campo Título")]
        [StringLength(20, ErrorMessage = "Digite no máximo 20 caracteres")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Por favor, preencha o campo Resumo")]
        public string Resumo { get; set; }
        public string Categoria { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public bool Publicado { get; set; }
    }
}
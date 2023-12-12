using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Logradouro
    {
        [Column("LogradouroId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório.")]
        [MaxLength(80, ErrorMessage = "Tamanho máximo de 60 caracteres.")]
        public string? Endereco { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatória.")]
        [MaxLength(80, ErrorMessage = "Tamanho máximo de 60 caracteres.")]
        public string? Cidade { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório.")]
        [MaxLength(2, ErrorMessage = "Tamanho máximo de 2 caracteres.")]
        public string? Estado { get; set; }

        [Required(ErrorMessage = "CEP é obrigatório.")]
        [MaxLength(9, ErrorMessage = "Tamanho máximo de 9 caracteres.")]
        public string? Cep { get; set; }

        [ForeignKey(nameof(Cliente))]
        public Guid Cliente { get; set; }
        public Cliente? cliente { get; set; }

    }
}

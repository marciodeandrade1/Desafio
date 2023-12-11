using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Cliente
    {
        [Column("ClienteId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome de cliente é obrigatório neste campo")]
        [MaxLength(60)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "E-mail do cliente é obrigatório neste campo")]
        [MaxLength(60)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Logotipo do cliente é obrigatório neste campo")]
        [MaxLength(60)]
        public string? Logotipo { get; set; }

        public ICollection<Logradouro> logradouros {  get; set; }



    }

   
}

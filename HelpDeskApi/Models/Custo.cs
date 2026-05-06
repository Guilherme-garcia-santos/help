using System.ComponentModel.DataAnnotations;

namespace HelpDeskApi.Models
{
    public class Custo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O valor do custo é obrigatório.")]
        [Range(0.01, 999999.99, ErrorMessage = "O valor do custo deve ser maior que zero.")]
        public decimal ValorCusto { get; set; }
    }
}
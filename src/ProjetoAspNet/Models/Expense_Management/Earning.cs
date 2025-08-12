using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoAspNet.Models.Expense_Management {
    [Table("Earning")]
    public class Earning{

        [Key]
        public int Id { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public bool IsFixed { get; set; } // É um gasto fixo ? Sim ; Não é um gasto variavél.
        public Earning(double amount, string description, bool isFixed) {
            Amount = amount;
            Description = description;
            IsFixed = isFixed;
        }
    }
}

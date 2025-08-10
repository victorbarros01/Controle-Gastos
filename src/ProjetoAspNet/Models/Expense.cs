using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoAspNet.Models {

    [Table("Expenses")]
    public class Expense {
        [Key]
        public int IdExpense { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public bool IsFixed { get; set; } // É um gasto fixo ? Sim ; Não é um gasto variavél.

        public Expense(double value, string description, bool isFixed) {
            Value = value;
            Description = description;
            IsFixed = isFixed;            
        }


    }
}

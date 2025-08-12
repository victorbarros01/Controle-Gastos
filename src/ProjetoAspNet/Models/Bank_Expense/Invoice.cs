using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoAspNet.Models.BankExpense {
    [Table("Invoice")]
    public class Invoice {

        [Key]
        public int Id { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public bool IsEntrance { get; set; } // É uma entrada de valores ? Sim ; Não é uma saída.

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [Required]
        public bool IsDivided { get; set; } // É parcelado? Sim ; Não é à vista.

        public int Installments { get; set; } // Quantidade de parcelas

        public Invoice(double amount, string description, bool isEntrance, DateTime date, bool isDivided, int installments)
        {
            Amount = amount;
            Description = description;
            IsEntrance = isEntrance;
            Date = date;
            IsDivided = isDivided;
            Installments = installments;
        }
    }
}

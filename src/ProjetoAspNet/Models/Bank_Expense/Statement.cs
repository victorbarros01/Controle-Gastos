using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoAspNet.Models.BankExpense {
    [Table("Statement")]
    public class Statement {

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
        public PaymentMethods PaymentMethod { get; set; }

        public Statement(double amount, string description, bool isEntrance, DateTime date, PaymentMethods paymentMethod) 
        {
            Amount = amount;
            Description = description;
            IsEntrance = isEntrance;
            Date = date;
            PaymentMethod = paymentMethod;
        }

    }
    public enum PaymentMethods { Pix = 0, Transferencia = 1, Debito = 2, Credito = 3 }

}

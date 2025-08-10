using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoAspNet.Models {
    [Table("BankExpenseItems")]
    public class BankExpenseItem {
        [Key]
        public int IdBankExpenseItem { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public bool IsEntrance { get; set; } // É uma entrada de valores ? Sim ; Não é uma saída.

        [Required]
        public bool? IsDivided { get; set; } // É parcelado? Sim ; Não é à vista.

        public int Installments { get; set; } // Quantidade de parcelas

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [Required]
        public ExpenseTypes ExpenseType { get; set; }

        [Required]
        public PaymentMethods PaymentMethod { get; set; }

        public BankExpenseItem() { }

        public BankExpenseItem(double value, string description, bool isEntrance, DateTime date, ExpenseTypes expenseType, PaymentMethods paymentMethod, bool isDivided, int installments) {
            Value = value;
            Description = description;
            IsEntrance = isEntrance;
            Date = date;
            ExpenseType = expenseType;
            if (ExpenseType == ExpenseTypes.Statement) {
                PaymentMethod = paymentMethod;
            } else {
                PaymentMethod = PaymentMethods.Credito;
            }


        }


    }

    public enum ExpenseTypes { Invoice = 0, Statement = 1 }
    public enum PaymentMethods { Pix = 0, Transferencia = 1, Debito = 2, Credito = 3 }
}

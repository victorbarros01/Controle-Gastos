using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoAspNet.Models {
    [Table("Earnings")]
    public class Earning {
        [Key]
        public int IdEarning { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public bool IsFixed { get; set; } // É um ganho fixo ? Sim ; Não é um gasto variavél.

        public Earning(double value, string description, bool isFixed) {
            Value = value;
            Description = description;
            IsFixed = isFixed;
        }
    }
}

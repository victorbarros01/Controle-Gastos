namespace ProjetoAspNet.ViewModel {
    public class ExpenseManagementViewModel {
        public int IdExpense { get; set; }
        public double AmountExpense { get; set; }
        public string DescriptionExpense { get; set; }
        public bool IsFixedExpense { get; set; }

        public int IdEarning { get; set; }
        public double AmountEarning { get; set; }
        public string DescriptionEarning { get; set; }
        public bool IsFixedEarning { get; set; }


    }
}

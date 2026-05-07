using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace task1
{
    public class FinanceViewModel : INotifyPropertyChanged
    {
        private readonly FinanceService _financeService = new FinanceService();

        public ObservableCollection<Transaction> Transactions { get; set; } = new ObservableCollection<Transaction>();

        private ObservableCollection<Transaction> _filteredTransactions = new ObservableCollection<Transaction>();
        public ObservableCollection<Transaction> FilteredTransactions
        {
            get => _filteredTransactions;
            set { _filteredTransactions = value; OnPropertyChanged(nameof(FilteredTransactions)); }
        }

        public ObservableCollection<CategorySummary> CategorySummaries { get; set; } = new ObservableCollection<CategorySummary>();

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(nameof(IsLoading)); }
        }
        public double Balance => _financeService.CalculateBalance(
            Transactions.Select(t => new TransactionModel
            {
                Date = t.Date,
                Category = t.Category,
                Amount = t.Amount
            }));

        public void AddTransaction(Transaction t)
        {
            t.PropertyChanged += Transaction_PropertyChanged;
            Transactions.Add(t);
            ApplyFilter(null);
            UpdateCategorySummaries();
            OnPropertyChanged(nameof(Balance));
        }

        public void RemoveTransaction(Transaction t)
        {
            Transactions.Remove(t);
            ApplyFilter(null);
            UpdateCategorySummaries();
            OnPropertyChanged(nameof(Balance));
        }

        public void ApplyFilter(DateTime? filterDate)
        {
            FilteredTransactions.Clear();
            var result = filterDate.HasValue
                ? Transactions.Where(t => t.Date.Date == filterDate.Value.Date)
                : (System.Collections.Generic.IEnumerable<Transaction>)Transactions;
            foreach (var t in result)
                FilteredTransactions.Add(t);
        }

        public async Task LoadDataAsync()
        {
            IsLoading = true;
            var data = await _financeService.LoadTransactionsAsync();
            foreach (var item in data)
            {
                var t = new Transaction
                {
                    Date = item.Date,
                    Category = item.Category,
                    Amount = item.Amount
                };
                t.PropertyChanged += Transaction_PropertyChanged;
                Transactions.Add(t);
            }
            ApplyFilter(null);
            UpdateCategorySummaries();
            OnPropertyChanged(nameof(Balance));
            IsLoading = false;
        }

        private void Transaction_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Transaction.Amount))
            {
                OnPropertyChanged(nameof(Balance));
                UpdateCategorySummaries();
            }
        }

        private void UpdateCategorySummaries()
        {
            CategorySummaries.Clear();
            var groups = Transactions
                .GroupBy(t => t.Category)
                .Select(g => new CategorySummary
                {
                    Category = g.Key,
                    Total = Math.Abs(g.Sum(t => t.Amount))
                });
            foreach (var g in groups)
                CategorySummaries.Add(g);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
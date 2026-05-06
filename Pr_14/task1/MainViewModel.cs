using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace task1
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Transaction> Transactions { get; set; } = new ObservableCollection<Transaction>();

        private ObservableCollection<Transaction> _filteredTransactions = new ObservableCollection<Transaction>();
        public ObservableCollection<Transaction> FilteredTransactions
        {
            get => _filteredTransactions;
            set { _filteredTransactions = value; OnPropertyChanged(nameof(FilteredTransactions)); }
        }

        private DateTime? _filterDate;
        public DateTime? FilterDate
        {
            get => _filterDate;
            set
            {
                _filterDate = value;
                OnPropertyChanged(nameof(FilterDate));
                ApplyFilter();
            }
        }

        private Transaction? _selectedTransaction;
        public Transaction? SelectedTransaction
        {
            get => _selectedTransaction;
            set { _selectedTransaction = value; OnPropertyChanged(nameof(SelectedTransaction)); }
        }

        public ICommand AddIncomeCommand { get; }
        public ICommand AddExpenseCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ClearFilterCommand { get; }

        public MainViewModel()
        {
            AddIncomeCommand = new RelayCommand(_ =>
            {
                var t = new Transaction { Date = DateTime.Now, Category = "Доход", Amount = 1000 };
                t.PropertyChanged += Transaction_PropertyChanged;
                Transactions.Add(t);
                ApplyFilter();
                OnPropertyChanged(nameof(Balance));
            });

            AddExpenseCommand = new RelayCommand(_ =>
            {
                var t = new Transaction { Date = DateTime.Now, Category = "Расход", Amount = -500 };
                t.PropertyChanged += Transaction_PropertyChanged;
                Transactions.Add(t);
                ApplyFilter();
                OnPropertyChanged(nameof(Balance));
            });

            DeleteCommand = new RelayCommand(_ =>
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Подтверждение",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    if (SelectedTransaction != null)
                        Transactions.Remove(SelectedTransaction);
                    ApplyFilter();
                    OnPropertyChanged(nameof(Balance));
                }
            }, _ => SelectedTransaction != null);

            ClearFilterCommand = new RelayCommand(_ =>
            {
                FilterDate = null;
            });
        }

        private void Transaction_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Transaction.Amount))
                OnPropertyChanged(nameof(Balance));
        }

        private void ApplyFilter()
        {
            FilteredTransactions.Clear();
            var result = FilterDate.HasValue
                ? Transactions.Where(t => t.Date.Date == FilterDate.Value.Date)
                : (IEnumerable<Transaction>)Transactions;

            foreach (var t in result)
                FilteredTransactions.Add(t);
        }

        public double Balance => Transactions.Sum(t => t.Amount);

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
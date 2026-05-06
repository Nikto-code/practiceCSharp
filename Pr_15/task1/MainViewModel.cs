using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace task1
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly FinanceViewModel _financeViewModel = new FinanceViewModel();

        public ObservableCollection<Transaction> FilteredTransactions => _financeViewModel.FilteredTransactions;
        public ObservableCollection<CategorySummary> CategorySummaries => _financeViewModel.CategorySummaries;

        public bool IsLoading => _financeViewModel.IsLoading;
        public double Balance => _financeViewModel.Balance;

        private DateTime? _filterDate;
        public DateTime? FilterDate
        {
            get => _filterDate;
            set
            {
                _filterDate = value;
                OnPropertyChanged(nameof(FilterDate));
                _financeViewModel.ApplyFilter(_filterDate);
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
        public ICommand LoadDataCommand { get; }

        public MainViewModel()
        {
            _financeViewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(FinanceViewModel.Balance))
                    OnPropertyChanged(nameof(Balance));
                if (e.PropertyName == nameof(FinanceViewModel.IsLoading))
                    OnPropertyChanged(nameof(IsLoading));
            };

            AddIncomeCommand = new RelayCommand(_ =>
            {
                _financeViewModel.AddTransaction(new Transaction
                {
                    Date = DateTime.Now,
                    Category = "Доход",
                    Amount = 1000
                });
                OnPropertyChanged(nameof(Balance));
            });

            AddExpenseCommand = new RelayCommand(_ =>
            {
                _financeViewModel.AddTransaction(new Transaction
                {
                    Date = DateTime.Now,
                    Category = "Расход",
                    Amount = -500
                });
                OnPropertyChanged(nameof(Balance));
            });

            DeleteCommand = new RelayCommand(_ =>
            {
                var result = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Подтверждение",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes && SelectedTransaction != null)
                {
                    _financeViewModel.RemoveTransaction(SelectedTransaction);
                    OnPropertyChanged(nameof(Balance));
                }
            }, _ => SelectedTransaction != null);

            ClearFilterCommand = new RelayCommand(_ => FilterDate = null);

            LoadDataCommand = new AsyncRelayCommand(async () =>
            {
                await _financeViewModel.LoadDataAsync();
                OnPropertyChanged(nameof(Balance));
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    public class CategorySummary
    {
        public string Category { get; set; } = string.Empty;
        public double Total { get; set; }
    }
}
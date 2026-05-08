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
        private readonly FinanceService _financeService = new FinanceService();
        private readonly NotificationService _notificationService = new NotificationService();
        private readonly UserModel _currentUser;

        public ChatViewModel Chat { get; } = new ChatViewModel();

        // Имя пользователя и роль для отображения в UI
        public string CurrentUsername => _currentUser.Username;
        public string CurrentUserRole => _currentUser.Role.ToString();
        public bool IsAdmin => _currentUser.Role == UserRole.Admin;

        public ObservableCollection<Transaction> Transactions { get; set; } =
            new ObservableCollection<Transaction>();

        private ObservableCollection<Transaction> _filteredTransactions =
            new ObservableCollection<Transaction>();
        public ObservableCollection<Transaction> FilteredTransactions
        {
            get => _filteredTransactions;
            set { _filteredTransactions = value; OnPropertyChanged(nameof(FilteredTransactions)); }
        }

        public ObservableCollection<CategorySummary> CategorySummaries { get; set; } =
            new ObservableCollection<CategorySummary>();

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(nameof(IsLoading)); }
        }

        private DateTime? _filterDate;
        public DateTime? FilterDate
        {
            get => _filterDate;
            set { _filterDate = value; OnPropertyChanged(nameof(FilterDate)); ApplyFilter(); }
        }

        private int _selectedMonth = DateTime.Now.Month;
        public int SelectedMonth
        {
            get => _selectedMonth;
            set
            {
                _selectedMonth = value;
                OnPropertyChanged(nameof(SelectedMonth));
                OnPropertyChanged(nameof(SelectedMonthName));
                ApplyFilter();
            }
        }

        public string SelectedMonthName =>
            new DateTime(DateTime.Now.Year, _selectedMonth, 1).ToString("MMMM yyyy");

        private Transaction? _selectedTransaction;
        public Transaction? SelectedTransaction
        {
            get => _selectedTransaction;
            set { _selectedTransaction = value; OnPropertyChanged(nameof(SelectedTransaction)); }
        }

        public double Balance => _financeService.CalculateBalance(
            Transactions.Select(t => new TransactionModel
            {
                Date = t.Date,
                Category = t.Category,
                Amount = t.Amount
            }));

        public ICommand AddIncomeCommand { get; }
        public ICommand AddExpenseCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ClearFilterCommand { get; }
        public ICommand LoadDataCommand { get; }
        public ICommand SendNotificationCommand { get; }
        public ICommand PrevMonthCommand { get; }
        public ICommand NextMonthCommand { get; }
        public ICommand LogoutCommand { get; }

        public MainViewModel(UserModel currentUser)
        {
            _currentUser = currentUser;

            AddIncomeCommand = new RelayCommand(_ =>
            {
                AddTransaction(new Transaction
                {
                    Date = DateTime.Now,
                    Category = "Доход",
                    Amount = 1000
                });
            });

            AddExpenseCommand = new RelayCommand(_ =>
            {
                AddTransaction(new Transaction
                {
                    Date = DateTime.Now,
                    Category = "Расход",
                    Amount = -500
                });
            });

            DeleteCommand = new RelayCommand(_ =>
            {
                var result = MessageBox.Show("Вы уверены?", "Подтверждение",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes && SelectedTransaction != null)
                {
                    Transactions.Remove(SelectedTransaction);
                    SaveToFile();
                    ApplyFilter();
                    UpdateCategorySummaries();
                    OnPropertyChanged(nameof(Balance));
                }
            }, _ => SelectedTransaction != null);

            ClearFilterCommand = new RelayCommand(_ =>
            {
                FilterDate = null;
                SelectedMonth = DateTime.Now.Month;
            });

            LoadDataCommand = new AsyncRelayCommand(async () =>
            {
                IsLoading = true;
                var data = await _financeService.LoadTransactionsAsync();
                foreach (var item in data)
                    AddTransaction(new Transaction
                    {
                        Date = item.Date,
                        Category = item.Category,
                        Amount = item.Amount
                    });
                IsLoading = false;
            });

            SendNotificationCommand = new RelayCommand(_ =>
            {
                _notificationService.SendNotification(
                    $"Баланс: {Balance} руб. [{DateTime.Now:HH:mm}]");
                MessageBox.Show("Уведомление отправлено!", "Уведомления",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            });
            PrevMonthCommand = new RelayCommand(_ =>
            {
                SelectedMonth = SelectedMonth > 1 ? SelectedMonth - 1 : 12;
            });

            NextMonthCommand = new RelayCommand(_ =>
            {
                SelectedMonth = SelectedMonth < 12 ? SelectedMonth + 1 : 1;
            });

            LogoutCommand = new RelayCommand(_ =>
            {
                var login = new LoginWindow();
                login.Show();
                Application.Current.Windows
                    .OfType<MainWindow>()
                    .FirstOrDefault()?.Close();
            });

            LoadFromFile();
        }

        private void AddTransaction(Transaction t)
        {
            t.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(Transaction.Amount))
                {
                    OnPropertyChanged(nameof(Balance));
                    UpdateCategorySummaries();
                }
            };
            Transactions.Add(t);
            SaveToFile();
            ApplyFilter();
            UpdateCategorySummaries();
            OnPropertyChanged(nameof(Balance));
        }

        private void ApplyFilter()
        {
            FilteredTransactions.Clear();
            var result = Transactions.Where(t => t.Date.Month == _selectedMonth);

            if (FilterDate.HasValue)
                result = result.Where(t => t.Date.Date == FilterDate.Value.Date);

            foreach (var t in result)
                FilteredTransactions.Add(t);
        }

        private void UpdateCategorySummaries()
        {
            CategorySummaries.Clear();
            var groups = Transactions
                .Where(t => t.Date.Month == _selectedMonth)
                .GroupBy(t => t.Category)
                .Select(g => new CategorySummary
                {
                    Category = g.Key,
                    Total = Math.Abs(g.Sum(t => t.Amount))
                });
            foreach (var g in groups)
                CategorySummaries.Add(g);
        }

        private void LoadFromFile()
        {
            var data = _financeService.LoadFromFile();
            foreach (var item in data)
                AddTransaction(new Transaction
                {
                    Date = item.Date,
                    Category = item.Category,
                    Amount = item.Amount
                });
        }

        private void SaveToFile()
        {
            _financeService.SaveToFile(Transactions.Select(t => new TransactionModel
            {
                Date = t.Date,
                Category = t.Category,
                Amount = t.Amount
            }));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
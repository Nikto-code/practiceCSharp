using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace task1
{
    public class FinanceDbViewModel : INotifyPropertyChanged
    {
        private readonly IRepository<TransactionEntity> _repo;

        public ObservableCollection<TransactionEntity> Items { get; } =
            new ObservableCollection<TransactionEntity>();

        private TransactionEntity? _selectedItem;
        public TransactionEntity? SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                CommandManager.InvalidateRequerySuggested();
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(nameof(IsLoading)); }
        }

        public ICommand LoadCommand { get; }
        public ICommand AddIncomeCommand { get; }
        public ICommand AddExpenseCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public FinanceDbViewModel()
        {
            _repo = new TransactionRepository();

            LoadCommand = new AsyncRelayCommand(async () =>
            {
                IsLoading = true;
                var list = await _repo.GetAllAsync();
                Items.Clear();
                foreach (var item in list)
                    Items.Add(item);
                IsLoading = false;
            });

            AddIncomeCommand = new AsyncRelayCommand(async () =>
            {
                var entity = new TransactionEntity
                {
                    Category = "Доход",
                    Amount = 1000,
                    Date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm")
                };
                await _repo.AddAsync(entity);
                await _repo.SaveAsync();
                await ((AsyncRelayCommand)LoadCommand).ExecuteAsync();
            });

            AddExpenseCommand = new AsyncRelayCommand(async () =>
            {
                var entity = new TransactionEntity
                {
                    Category = "Расход",
                    Amount = -500,
                    Date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm")
                };
                await _repo.AddAsync(entity);
                await _repo.SaveAsync();
                await ((AsyncRelayCommand)LoadCommand).ExecuteAsync();
            });

            UpdateCommand = new AsyncRelayCommand(async () =>
            {
                if (SelectedItem == null) return;
                await _repo.UpdateAsync(SelectedItem);
                await _repo.SaveAsync();
                await ((AsyncRelayCommand)LoadCommand).ExecuteAsync();
            }, () => SelectedItem != null);

            DeleteCommand = new AsyncRelayCommand(async () =>
            {
                if (SelectedItem == null) return;
                var result = MessageBox.Show(
                    "Удалить запись?", "Подтверждение",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    await _repo.DeleteAsync(SelectedItem);
                    await _repo.SaveAsync();
                    await ((AsyncRelayCommand)LoadCommand).ExecuteAsync();
                }
            }, () => SelectedItem != null);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace z1
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Transaction> Transactions { get; set; } = new ObservableCollection<Transaction>();

        private Transaction _selectedTransaction;
        public Transaction SelectedTransaction
        {
            get => _selectedTransaction;
            set { _selectedTransaction = value; OnPropertyChanged(nameof(SelectedTransaction)); }
        }

        public ICommand AddIncomeCommand { get; }
        public ICommand AddExpenseCommand { get; }
        public ICommand DeleteCommand { get; }

        public MainViewModel()
        {
            AddIncomeCommand = new RelayCommand(_ => {
                Transactions.Add(new Transaction { Date = DateTime.Now, Category = "Доход", Amount = 1000 });
                OnPropertyChanged(nameof(Balance));
            });

            AddExpenseCommand = new RelayCommand(_ => {
                Transactions.Add(new Transaction { Date = DateTime.Now, Category = "Расход", Amount = -500 });
                OnPropertyChanged(nameof(Balance));
            });

            DeleteCommand = new RelayCommand(_ => {
                var result = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    Transactions.Remove(SelectedTransaction);
                    OnPropertyChanged(nameof(Balance));
                }
            }, _ => SelectedTransaction != null);
        }

        public double Balance => Transactions.Sum(t => t.Amount);

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
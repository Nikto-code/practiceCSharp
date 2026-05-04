using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace z1
{
    public class MainViewModel
    {
        public ObservableCollection<Transaction> Transactions { get; set; } = new ObservableCollection<Transaction>();

        public ICommand AddTransactionCommand { get; }
        public ICommand DeleteTransactionCommand { get; }

        public Transaction SelectedTransaction { get; set; }

        public MainViewModel()
        {
            AddTransactionCommand = new RelayCommand(_ => AddTransaction());
            DeleteTransactionCommand = new RelayCommand(
                _ => DeleteTransaction(),
                _ => SelectedTransaction != null
            );
        }

        private void AddTransaction()
        {
            Transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Category = "Новая",
                Amount = 100
            });
        }

        private void DeleteTransaction()
        {
            if (SelectedTransaction == null) return;

            var result = MessageBox.Show("Удалить запись?", "Подтверждение", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                Transactions.Remove(SelectedTransaction);
            }
        }

        public double Balance => Transactions.Sum(t => t.Amount);
    }
}

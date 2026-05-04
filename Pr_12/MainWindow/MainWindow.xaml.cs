using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinanceApp
{
    public partial class MainWindow : Window
    {
        private List<Transaction> incomes = new List<Transaction>();
        private List<Transaction> expenses = new List<Transaction>();

        public MainWindow()
        {
            InitializeComponent();
            UpdateUI();
        }

        private void AddIncome_Click(object sender, RoutedEventArgs e)
        {
            incomes.Add(new Transaction
            {
                Date = DateTime.Now,
                Category = "Доход",
                Amount = 1000
            });

            UpdateUI();
        }

        private void AddExpense_Click(object sender, RoutedEventArgs e)
        {
            expenses.Add(new Transaction
            {
                Date = DateTime.Now,
                Category = "Расход",
                Amount = 500
            });

            UpdateUI();
        }

        private void UpdateUI()
        {
            IncomeGrid.ItemsSource = null;
            IncomeGrid.ItemsSource = incomes;

            ExpenseGrid.ItemsSource = null;
            ExpenseGrid.ItemsSource = expenses;

            double balance = incomes.Sum(x => x.Amount) - expenses.Sum(x => x.Amount);
            BalanceText.Text = $"Баланс: {balance}";
        }
    }
}
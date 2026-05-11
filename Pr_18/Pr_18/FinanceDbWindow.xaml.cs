using System.Windows;

namespace task1
{
    public partial class FinanceDbWindow : Window
    {
        public FinanceDbWindow()
        {
            InitializeComponent();
            DataContext = new FinanceDbViewModel();
        }
    }
}
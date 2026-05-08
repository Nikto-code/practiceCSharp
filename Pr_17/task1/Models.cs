using System;
using System.ComponentModel;

namespace task1
{
    public class TransactionModel
    {
        public DateTime Date { get; set; }
        public string Category { get; set; } = string.Empty;
        public double Amount { get; set; }
    }

    public class CategoryModel
    {
        public string Name { get; set; } = string.Empty;
    }

    public class CategorySummary
    {
        public string Category { get; set; } = string.Empty;
        public double Total { get; set; }
    }

    public class Transaction : INotifyPropertyChanged
    {
        private double _amount;
        private DateTime _date;
        private string _category = string.Empty;

        public DateTime Date
        {
            get => _date;
            set { _date = value; OnPropertyChanged(nameof(Date)); }
        }

        public string Category
        {
            get => _category;
            set { _category = value; OnPropertyChanged(nameof(Category)); }
        }

        public double Amount
        {
            get => _amount;
            set { _amount = value; OnPropertyChanged(nameof(Amount)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public enum UserRole { Admin, User }

    public class UserModel
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.User;
    }
}
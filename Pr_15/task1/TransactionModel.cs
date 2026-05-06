using System;

namespace task1
{
    public class TransactionModel
    {
        public DateTime Date { get; set; }
        public string Category { get; set; } = string.Empty;
        public double Amount { get; set; }
    }
}
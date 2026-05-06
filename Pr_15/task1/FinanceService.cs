using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace task1
{
    public class FinanceService
    {
        public async Task<List<TransactionModel>> LoadTransactionsAsync()
        {
            await Task.Delay(3000);
            return new List<TransactionModel>
            {
                new TransactionModel { Date = DateTime.Now, Category = "Доход", Amount = 5000 },
                new TransactionModel { Date = DateTime.Now, Category = "Расход", Amount = -1500 },
                new TransactionModel { Date = DateTime.Now, Category = "Доход", Amount = 3000 },
                new TransactionModel { Date = DateTime.Now, Category = "Расход", Amount = -500 }
            };
        }

        public double CalculateBalance(IEnumerable<TransactionModel> transactions)
        {
            double balance = 0;
            foreach (var t in transactions)
                balance += t.Amount;
            return balance;
        }
    }
}
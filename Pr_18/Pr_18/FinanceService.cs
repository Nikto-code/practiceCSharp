using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace task1
{
    public class FinanceService
    {
        private const string FilePath = "finance.json";

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

        public List<TransactionModel> LoadFromFile()
        {
            if (!File.Exists(FilePath)) return new List<TransactionModel>();
            string json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<TransactionModel>>(json)
                   ?? new List<TransactionModel>();
        }

        public void SaveToFile(IEnumerable<TransactionModel> transactions)
        {
            string json = JsonConvert.SerializeObject(transactions, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
    }
}
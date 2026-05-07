using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace task1
{
    public class FinanceStorageService
    {
        private const string FilePath = "finance.json";

        public List<TransactionModel> LoadTransactions()
        {
            if (!File.Exists(FilePath))
                return new List<TransactionModel>();

            string json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<TransactionModel>>(json)
                   ?? new List<TransactionModel>();
        }

        public void SaveTransactions(IEnumerable<TransactionModel> transactions)
        {
            string json = JsonConvert.SerializeObject(transactions, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
    }
}
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace task1
{
    public class TransactionRepository : IRepository<TransactionEntity>
    {
        private const string ConnString = "Data Source=finance.db";

        public TransactionRepository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var conn = new SqliteConnection(ConnString);
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Categories (
                    Id   INTEGER PRIMARY KEY,
                    Name TEXT NOT NULL
                );
                INSERT OR IGNORE INTO Categories(Id, Name) VALUES(1, 'Доход');
                INSERT OR IGNORE INTO Categories(Id, Name) VALUES(2, 'Расход');
                INSERT OR IGNORE INTO Categories(Id, Name) VALUES(3, 'Инвестиции');

                CREATE TABLE IF NOT EXISTS Transactions (
                    Id         INTEGER PRIMARY KEY AUTOINCREMENT,
                    CategoryId INTEGER NOT NULL,
                    Amount     REAL,
                    Date       TEXT,
                    FOREIGN KEY(CategoryId) REFERENCES Categories(Id)
                );";
            cmd.ExecuteNonQuery();
        }

        // READ
        public async Task<List<TransactionEntity>> GetAllAsync()
        {
            var result = new List<TransactionEntity>();
            using var conn = new SqliteConnection(ConnString);
            await conn.OpenAsync();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT t.Id, c.Name, t.Amount, t.Date
                FROM Transactions t
                JOIN Categories c ON t.CategoryId = c.Id
                ORDER BY t.Date DESC";

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                result.Add(new TransactionEntity
                {
                    Id = reader.GetInt32(0),
                    Category = reader.GetString(1),
                    Amount = reader.GetDouble(2),
                    Date = reader.GetString(3)
                });
            }
            return result;
        }

        public async Task AddAsync(TransactionEntity item)
        {
            using var conn = new SqliteConnection(ConnString);
            await conn.OpenAsync();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Transactions (CategoryId, Amount, Date)
                VALUES (
                    (SELECT Id FROM Categories WHERE Name = $cat),
                    $amount,
                    $date
                )";
            cmd.Parameters.AddWithValue("$cat", item.Category);
            cmd.Parameters.AddWithValue("$amount", item.Amount);
            cmd.Parameters.AddWithValue("$date", item.Date);
            await cmd.ExecuteNonQueryAsync();
        }

        // UPDATE
        public async Task UpdateAsync(TransactionEntity item)
        {
            using var conn = new SqliteConnection(ConnString);
            await conn.OpenAsync();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                UPDATE Transactions
                SET CategoryId = (SELECT Id FROM Categories WHERE Name = $cat),
                    Amount     = $amount,
                    Date       = $date
                WHERE Id = $id";
            cmd.Parameters.AddWithValue("$cat", item.Category);
            cmd.Parameters.AddWithValue("$amount", item.Amount);
            cmd.Parameters.AddWithValue("$date", item.Date);
            cmd.Parameters.AddWithValue("$id", item.Id);
            await cmd.ExecuteNonQueryAsync();
        }
        public async Task DeleteAsync(TransactionEntity item)
        {
            using var conn = new SqliteConnection(ConnString);
            await conn.OpenAsync();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Transactions WHERE Id = $id";
            cmd.Parameters.AddWithValue("$id", item.Id);
            await cmd.ExecuteNonQueryAsync();
        }

        public Task SaveAsync() => Task.CompletedTask;
    }
}
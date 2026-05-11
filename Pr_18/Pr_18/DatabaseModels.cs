namespace task1
{
    public class TransactionEntity
    {
        public int Id { get; set; }
        public string Date { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public double Amount { get; set; }
    }
}
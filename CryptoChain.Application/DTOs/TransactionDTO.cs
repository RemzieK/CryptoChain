namespace CryptoChain.Application.DTOs
{
    public class TransactionDTO
    {
        public Guid TransactionId { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

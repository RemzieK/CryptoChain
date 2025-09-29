namespace CryptoChain.Domain.Entities
{
    public class Transaction
    {
        public Guid TransactionId { get; }
        public Guid SenderId { get; }
        public Guid ReceiverId { get; }
        public decimal Amount { get; }
        public DateTime Timestamp { get; }

        public Transaction(Guid transactionId, Guid senderId, Guid receiverId, decimal amount)
        {
            TransactionId = transactionId;
            SenderId = senderId;
            ReceiverId = receiverId;
            Amount = amount;
            Timestamp = DateTime.UtcNow;
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    [PrimaryKey(nameof(Id))]
    public class CashMovementsResponse
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public required TransactionType Type { get; set; }
        public Guid? SaleId { get; set; }
    }
}
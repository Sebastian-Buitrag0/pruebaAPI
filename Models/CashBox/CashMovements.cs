
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace pruebaAPI.Models
{
    [PrimaryKey(nameof(Id))]
    public class CashMovements
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public Guid? SaleId { get; set; }
        
        [ForeignKey(nameof(SaleId))]
        public Sale? Sale { get; set; }
    }

    public enum TransactionType
    {
        Income,
        Expense
    }
}
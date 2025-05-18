using System;
using System.ComponentModel.DataAnnotations;

namespace pruebaAPI.Models
{
    public class CashMovementsRequest
    {
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Transaction Type is required")]
        public TransactionType Type { get; set; }
        
        public Guid? SaleId { get; set; }
    }
}
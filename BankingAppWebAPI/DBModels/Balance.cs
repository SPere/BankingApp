using System.ComponentModel.DataAnnotations;

namespace BankingAppWebAPI.DBModels
{
    public class Balance
    {
        [Key]
        public int UserId { get; set; }
        public Currency Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
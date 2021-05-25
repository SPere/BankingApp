namespace BankingAppWebAPI.Models
{
    public class WithdrawRequest
    {
        public int UserId { get; set; } 
        public decimal Amount { get; set; }
    }
}

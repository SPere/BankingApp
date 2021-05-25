using BankingAppWebAPI.DBModels;

namespace BankingAppWebAPI.Models
{
    public class BalanceResponse
    {
        public Balance CurrentBalance { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}

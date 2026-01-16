namespace FCBankDemo.DTO
{
    public class CreateAccountDTO
    {
        public string AccountName { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public string ClientId { get; set; } = string.Empty;
        public decimal InitialDeposit { get; set; }
        public CurrencyDTO Currency { get; set; }


    }
}

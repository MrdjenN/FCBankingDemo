namespace FCBankDemo.DTO
{
    public class WithdrawAccountDTO
    {
        public decimal Amount { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
    }
}
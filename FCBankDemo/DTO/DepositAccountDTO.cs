namespace FCBankDemo.DTO
{
    /// <summary>
    /// I will assume we deposit only in one currency for simplicity (EUR)
    /// </summary>
    public class DepositAccountDTO
    {
        public decimal Amount { get; set; }
        public string AccountNumber{ get; set; } = string.Empty;
    }
}
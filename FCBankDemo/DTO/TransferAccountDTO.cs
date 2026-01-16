namespace FCBankDemo.DTO
{
    public class TransferAccountDTO
    {
        public decimal Amount { get; set; }
        public string SourceAccountNumber { get; set; } = string.Empty;
        public string DestinationAccountNumber { get; set; } = string.Empty;
    }
}
using FCBankDemo.Model;

namespace FCBankDemo.DTO
{
    public class AccountDTO
    {
        public Int64 Id { get; set; }
        /// <summary>
        /// Gets or sets the name of the account associated with this instance.
        /// </summary>
        public string AccountName { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the unique identifier for the client application.
        /// </summary>
        public string ClientId { get; set; } = string.Empty;
        /// <summary>
        /// The account status.
        /// </summary>
        public AccountStatusDTO Status { get;  set; }
        /// <summary>
        /// The account currency.
        /// </summary>
        public CurrencyDTO Currency { get; set; }
        /// <summary>
        /// The total amount of cash in the account.
        /// </summary>
        public decimal Balance { get; set; }
        /// <summary>
		/// The account number.
		/// </summary>
		public string AccountNumber { get; set; }
        /// <summary>
		/// The account creation time.
		/// </summary>
		public DateTime CreatedAt { get; set; }
        /// <summary>
        /// The last update time.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}

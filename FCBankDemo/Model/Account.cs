using Microsoft.EntityFrameworkCore;

namespace FCBankDemo.Model
{
    public enum Currency
    {
        EUR,
        RSD,
        USD,
    }

    /// <summary>
	/// The account statuses.
	/// </summary>
	public enum AccountStatus
    {
        None,
        Active,
        Suspended,
        Disabled,
        Archived
    }
    [Index(nameof(AccountNumber), IsUnique = true)]
    [PrimaryKey(nameof(AccountNumber))]
    public class Account
    {
        #region Properties
        /// <summary>
        /// Gets or sets the name of the account associated with this instance.
        /// </summary>
        public string AccountName { get; private set; } = string.Empty;
        /// <summary>
        /// Gets or sets the unique identifier for the client.
        /// </summary>
        public string ClientId { get; private set; } = string.Empty;
        /// <summary>
        /// The account status.
        /// </summary>
        public AccountStatus Status { get; private set; }
        /// <summary>
        /// The account currency.
        /// </summary>
        public Currency Currency { get; private set; }
        /// <summary>
        /// The total amount of cash in the account.
        /// </summary>
        public decimal Balance { get; private set; }
        /// <summary>
		/// The account number.
		/// </summary>
		public string AccountNumber { get; private set; }
        /// <summary>
		/// The account creation time.
		/// </summary>
		public DateTime CreatedAt { get; private set; }
        /// <summary>
        /// The last update time.
        /// </summary>
        public DateTime UpdatedAt { get; private set; }

        //todo
        /// <summary>
        ///// ReservedBallance todo????
        ///// </summary>
        //public decimal ReservedBallance { get; private set; }
        #endregion Properties

        public Account()
        {
            AccountName = string.Empty;
            ClientId = string.Empty;
            AccountNumber = string.Empty;
        }

        public Account(string accountName, string clientId, AccountStatus status, Currency currency, decimal balance, string accountNumber)
        {
            AccountName = accountName;
            ClientId = clientId;
            Status = status;
            Currency = currency;
            Balance = balance;
            AccountNumber = accountNumber;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
        }

        public bool SetBalance(decimal amount)
        {
            Balance = amount;
            UpdatedAt = DateTime.UtcNow;
            return true;
            // can add logs here...
        }

    }

}

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
    //[Index(nameof(AccountNumber), IsUnique = true)]
    [PrimaryKey(nameof(Id))]
    public class Account
    {
        #region Properties
        public Int64 Id { get; set; }
        /// <summary>
        /// Account owner identifier.
        /// </summary>
        public long UserId { get; private set; }
        /// <summary>
        /// The account owner full name.
        /// </summary>
        public string UserFullName { get; private set; }
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
        //      /// <summary>
        ///// ReservedBallance todo????
        ///// </summary>
        //public decimal ReservedBallance { get; private set; }
        #endregion Properties
    }
}

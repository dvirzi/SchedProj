using System.Collections.Generic;

namespace SWE346.Module5.Problem1.DomainObjects  {
    /// <summary>
    /// Represents an Account.
    /// </summary>
    public class Account {
        /// <summary>
        /// The name of the Account.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The current balance of the account.
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// The type of the account.
        /// </summary>
        public AccountType Type { get; set; }

        /// <summary>
        /// Creates an instance of an Account
        /// </summary>
        public Account()
        {
            Type = AccountType.Checking;
            Name = string.Empty;
            Balance = 0.0;
        }

        /// <summary>
        /// Creates an Instance of an Account 
        /// </summary>
        /// <param name="name">The name of the account</param>
        /// <param name="balance">The balance of the account</param>
        /// <param name="type">The type of account</param>
        public Account(string name, double balance, AccountType type){
            Name = name;
            Balance = balance;
            Type = type;
        }

        /// <summary>
        /// Enumeration representing the types of Accounts
        /// </summary>
        public enum AccountType{
            Checking = 0,
            Savings,
            MoneyMarket
        }

        #region Comparers
        /// <summary>
        /// Implements IComparer and will compare the Balance property on an
        /// Account Object
        /// </summary>
        public class BalanceComparer : IComparer<Account> {
            private readonly int alteration;
            
            public BalanceComparer(bool decending){
                alteration = decending ? -1 : 1;
            }

            public int Compare(Account x, Account y) {
                return x.Balance.CompareTo(y.Balance) * alteration;
            }
        }
        /// <summary>
        /// Implements IComparer and will compare the Name property on an
        /// Account Object
        /// </summary>
        public class NameComparer : IComparer<Account> {
            private readonly int alteration;
            
            public NameComparer(bool decending){
                alteration = decending ? -1 : 1;
            }

            public int Compare(Account x, Account y) {
                return x.Name.CompareTo(y.Name) * alteration;
            }
        }
        #endregion
    }
}



using System.Collections.Generic;
using SWE346.Module5.DomainObjects;

namespace SWE346.Module5.Problem1.DomainObjects 
{
    /// <summary>
    /// Collection of accounts
    /// </summary>
    public class AccountCollection  :  List<Account>
    {
        /// <summary>
        /// Enumeration containing the sortable columns
        /// </summary>
        protected enum Columns{
            Name,Balance
        }

        protected Columns lastSortedColumn = Columns.Name;
        protected bool wasLastSortDecending;

        /// <summary>
        /// Sorts the collection by name. The ascending/descending direction
        /// is alternated.
        /// </summary>
        public void SortByName(){
            if(lastSortedColumn ==Columns.Name)
                SortByName(!wasLastSortDecending);
            else
                SortByName(false);
        }

        /// <summary>
        /// Sorts the collection by name. 
        /// </summary>
        /// <param name="descending">Set to true for descending, false for ascending</param>
        public void SortByName(bool descending){
            Sort(new Account.NameComparer(descending));
            lastSortedColumn = Columns.Name;
            wasLastSortDecending = descending;
        }

        /// <summary>
        /// Sorts the collection by balance. The ascending/descending direction
        /// is alternated.
        /// </summary>
        public void SortByBalance(){
            if(lastSortedColumn ==Columns.Balance)
                SortByBalance(!wasLastSortDecending);
            else
                SortByBalance(false);
        }

        /// <summary>
        /// Sorts the collection by balance.
        /// </summary>
        /// <param name="descending">Set to true for descending, false for ascending</param>
        public void SortByBalance(bool descending){
            Sort(new Account.BalanceComparer(descending));
            lastSortedColumn = Columns.Balance;
            wasLastSortDecending = descending;
        }
    }
}



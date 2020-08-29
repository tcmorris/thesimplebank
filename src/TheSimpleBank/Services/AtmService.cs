using TheSimpleBank.Constants;
using TheSimpleBank.Models;

namespace TheSimpleBank.Services
{
    public class AtmService
    {
        public Account CurrentAccount { get; set; }
        public Atm CurrentAtm { get; set; }
     
        /// <summary>
        /// Set up the ATM with initial amount.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public string SetupAtm(int amount)
        {
            CurrentAtm = new Atm(amount);
            if (CurrentAtm.IsEmpty)
            {                
                return ErrorCodes.NoCashError;
            }
            return string.Empty;
        }

        /// <summary>
        /// Open a session using the customer details.
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="pinNumber"></param>
        /// <param name="providedPin"></param>
        /// <returns></returns>
        public string OpenSession(string accountNumber, string pinNumber, string providedPin)
        {
            if (providedPin != pinNumber)
            {                
                return ErrorCodes.AccountError;
            }

            CurrentAccount = new Account(accountNumber, pinNumber);
            return string.Empty;
        }

        /// <summary>
        /// Close the customers session.
        /// </summary>
        public void CloseSession()
        {
            CurrentAccount = null;
        }

        /// <summary>
        /// Update the balance for the current customer.
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="overdraft"></param>
        /// <returns></returns>
        public string UpdateBalance(int balance, int overdraft)
        {
            if (CurrentAccount == null)
            {                
                return ErrorCodes.AccountError;
            }

            CurrentAccount.Balance = balance;
            CurrentAccount.Overdraft = overdraft;
            return string.Empty;
        }

        /// <summary>
        /// Check the balance of the current customer.
        /// </summary>
        /// <returns>the current balance</returns>
        public string CheckBalance()
        {
            if (CurrentAccount == null)
            {
                return ErrorCodes.AccountError;
            }

            return CurrentAccount.Balance.ToString();
        }

        /// <summary>
        /// Withdraw funds from the current customers account.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>the updated balance</returns>
        public string WithdrawFunds(int amount)
        {
            if (CurrentAtm == null || CurrentAtm.IsEmpty)
            {
                return ErrorCodes.NoCashError;
            }
            if (CurrentAccount == null)
            {
                return ErrorCodes.AccountError;
            }

            if (amount <= 0
                || amount > CurrentAtm.Balance
                || amount > CurrentAccount.AvailableFunds)
            {                
                return ErrorCodes.WithdrawalError;
            }

            CurrentAccount.Balance -= amount;
            CurrentAtm.Balance -= amount;
            return CurrentAccount.Balance.ToString();
        }        
    }
}

namespace TheSimpleBank.Models
{
    public class Account
    {
        public Account(string accountNumber, string pinNumber)
        {
            AccountNumber = accountNumber;
            PinNumber = pinNumber;
        }

        public string AccountNumber { get; }

        public string PinNumber { get; }        

        public int Balance { get; set; }

        public int Overdraft { get; set; }

        public int AvailableFunds
        {
            get
            {
                return Balance + Overdraft;
            }
        }
    }
}

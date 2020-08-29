namespace TheSimpleBank.Models
{
    public class Atm
    {
        public Atm(int initialBalance)
        {
            Balance = initialBalance;
        }

        public int Balance { get; set; }

        public bool IsEmpty
        {
            get
            {
                return Balance <= 0;
            }
        }
    }
}

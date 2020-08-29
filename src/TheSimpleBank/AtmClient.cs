using TheSimpleBank.Constants;
using TheSimpleBank.Services;

namespace TheSimpleBank
{
    /// <summary>
    /// Client for the ATM.
    /// </summary>
    public class AtmClient
    {
        private readonly AtmService _atmService;
        private readonly InputService _inputService;

        public AtmClient()
        {
            _atmService = new AtmService();
            _inputService = new InputService();
        }

        /// <summary>
        /// Process the input command against the ATM.
        /// </summary>
        /// <param name="input">input command</param>
        /// <returns>input response</returns>
        public string ProcessInput(string input)
        {
            var instruction = _inputService.GetInstruction(input);
            switch (instruction)
            {
                case Instruction.SetupAtm:
                    int.TryParse(input, out int amount);
                    return _atmService.SetupAtm(amount);
                    
                case Instruction.LoadAccount:
                    var loadAccountArgs = input.Split(" ");
                    return _atmService.OpenSession(loadAccountArgs[0], loadAccountArgs[1], loadAccountArgs[2]);                    

                case Instruction.UpdateBalance:
                    var updateBalanceArgs = input.Split(" ");
                    int.TryParse(updateBalanceArgs[0], out int balance);
                    int.TryParse(updateBalanceArgs[1], out int overdraft);
                    return _atmService.UpdateBalance(balance, overdraft);
                    
                case Instruction.CheckBalance:
                    return _atmService.CheckBalance();
                    
                case Instruction.WithdrawFunds:
                    var widthdrawFundsArgs = input.Split(" ");
                    int.TryParse(widthdrawFundsArgs[1], out int withdraw);
                    return _atmService.WithdrawFunds(withdraw);
                    
                case Instruction.Blank:                    
                    _atmService.CloseSession();
                    break;
            }

            return string.Empty;
        }        
    }
}

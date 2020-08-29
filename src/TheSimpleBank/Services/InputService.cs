using System;
using TheSimpleBank.Constants;

namespace TheSimpleBank.Services
{
    public class InputService
    {
        /// <summary>
        /// Parse the input to provide the requested instruction.
        /// </summary>
        /// <param name="input">the input</param>
        /// <returns>the instruction</returns>
        public Instruction GetInstruction(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return Instruction.Blank;
            }

            if (input.StartsWith("B", StringComparison.InvariantCultureIgnoreCase))
            {
                return Instruction.CheckBalance;
            }

            if (input.StartsWith("W", StringComparison.InvariantCultureIgnoreCase))
            {
                return Instruction.WithdrawFunds;
            }

            var inputSplit = input.Split(" ");
            switch (inputSplit.Length)
            {
                case 1:
                    return Instruction.SetupAtm;
                case 2: 
                    return Instruction.UpdateBalance;
                case 3:
                    return Instruction.LoadAccount;
                default:
                    return Instruction.Blank;
            }            
        }
    }
}

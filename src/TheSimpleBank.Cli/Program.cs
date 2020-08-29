using System;

namespace TheSimpleBank.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The Simple Bank");
            Console.WriteLine("---------------");
            var client = new AtmClient();

            while (true)
            {
                var input = Console.ReadLine();
                if (input.ToUpper() == "EXIT")
                {
                    Environment.Exit(0);
                }

                var response = client.ProcessInput(input);
                if (!string.IsNullOrEmpty(response))
                {
                    Console.WriteLine(response);
                }
            }
        }
    }
}

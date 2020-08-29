using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheSimpleBank.Constants;

namespace TheSimpleBank.UnitTests
{
    [TestClass]
    public class AtmClientTests
    {
        private AtmClient _atmClient;

        [TestInitialize]
        public void Setup()
        {
            _atmClient = new AtmClient();
        }

        [TestMethod]
        public void RunScript_Ok()
        {
            _atmClient.ProcessInput("8000");
            _atmClient.ProcessInput("");
            _atmClient.ProcessInput("12345678 1234 1234");
            _atmClient.ProcessInput("500 100");

            var output1 = _atmClient.ProcessInput("B");
            Assert.AreEqual("500", output1);

            var output2 = _atmClient.ProcessInput("W 100");
            Assert.AreEqual("400", output2);

            _atmClient.ProcessInput("");
            _atmClient.ProcessInput("87654321 4321 4321");
            _atmClient.ProcessInput("100 0");
            var output3 = _atmClient.ProcessInput("W 10");
            Assert.AreEqual("90", output3);

            _atmClient.ProcessInput("");
            _atmClient.ProcessInput("87654321 4321 4321");
            _atmClient.ProcessInput("0 0");
            var output4 = _atmClient.ProcessInput("W 10");
            Assert.AreEqual(ErrorCodes.WithdrawalError, output4);

            var output5 = _atmClient.ProcessInput("B");
            Assert.AreEqual("0", output5);
        }
    }
}

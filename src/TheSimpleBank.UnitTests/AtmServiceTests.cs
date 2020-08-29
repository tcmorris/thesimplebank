using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheSimpleBank.Constants;
using TheSimpleBank.Services;

namespace TheSimpleBank.UnitTests
{
    [TestClass]
    public class AtmServiceTests
    {
        private AtmService _atmService;

        [TestInitialize]
        public void Setup()
        {
            _atmService = new AtmService();
            _atmService.SetupAtm(8000);
        }

        [TestMethod]
        public void OpenSession_ValidPin()
        {
            var response = _atmService.OpenSession("12345678", "1234", "1234");

            Assert.IsNotNull(_atmService.CurrentAccount);
            Assert.AreEqual(string.Empty, response);
            _atmService.CloseSession();
        }

        [TestMethod]
        public void OpenSession_InvalidPin()
        {
            var response = _atmService.OpenSession("12345678", "1234", "4321");

            Assert.IsNull(_atmService.CurrentAccount);
            Assert.AreEqual(ErrorCodes.AccountError, response);
            _atmService.CloseSession();
        }

        [TestMethod]
        public void UpdateBalance_Ok()
        {
            _atmService.OpenSession("12345678", "1234", "1234");
            _atmService.UpdateBalance(500, 100);

            Assert.AreEqual(500, _atmService.CurrentAccount.Balance);
            Assert.AreEqual(100, _atmService.CurrentAccount.Overdraft);
            Assert.AreEqual(600, _atmService.CurrentAccount.AvailableFunds);
            _atmService.CloseSession();
        }

        [TestMethod]
        public void WithdrawFunds_Valid()
        {
            _atmService.OpenSession("12345678", "1234", "1234");
            _atmService.UpdateBalance(500, 100);
            var response = _atmService.WithdrawFunds(100);

            Assert.AreEqual("400", response);
            _atmService.CloseSession();
        }

        [TestMethod]
        public void WithdrawFunds_Invalid()
        {
            _atmService.OpenSession("87654321", "4321", "4321");
            _atmService.UpdateBalance(0, 0);
            var response = _atmService.WithdrawFunds(10);

            Assert.AreEqual(ErrorCodes.WithdrawalError, response);
            _atmService.CloseSession();
        }

        [TestMethod]
        public void CheckBalance_Ok()
        {
            _atmService.OpenSession("87654321", "4321", "4321");
            _atmService.UpdateBalance(0, 0);
            var response = _atmService.CheckBalance();

            Assert.AreEqual("0", response);
            _atmService.CloseSession();
        }
    }
}

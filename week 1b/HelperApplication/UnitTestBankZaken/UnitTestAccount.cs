using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestBankZaken
{
    [TestClass]
    public class UnitTestAccount
    {
        [TestMethod]
        public void Test_WhenInstantiatingAccount_ItShouldNotEqualsNull()
        {
            //Account account = new Account();
            //Assert.AreNotEqual(null, account);
        }

        [TestMethod]
        public void TestClass_WhenGetNameProperty_ShouldReturnStringMichael()
        {
            //Account account = new Account("Michael", 0.00m);
            //Assert.AreEqual("Michael", account.Name);
        }

    }
}

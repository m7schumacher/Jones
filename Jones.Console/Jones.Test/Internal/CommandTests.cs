using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jones.Domain;

namespace Jones.Test.Internal
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void TestBasicCommand()
        {
            Command command = new Command("this is a test");
            Assert.IsFalse(command.IsQuestion);
            Assert.AreEqual(CommandType.Noun, command.Type);
        }

        [TestMethod]
        public void TestQuestion()
        {
            Command command = new Command("is this a test?");
            Assert.IsTrue(command.IsQuestion);
            Assert.AreEqual(CommandType.Noun, command.Type);
        }

        [TestMethod]
        public void TestAdjectiveBasedCommand()
        {
            Command command = new Command("how windy is it?");
            Assert.IsTrue(command.IsQuestion);
            Assert.AreEqual(CommandType.Adjective, command.Type);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Jones.Domain.Commands;

namespace Jones.Test
{
    [TestClass]
    public class KernelTest
    {
        [TestMethod]
        public void TestBasicCommand_TwoTiers()
        {
            string[] inputPhrases = new string[]
            {
                "{0}{1}",
                "{0}{1}"
            };

            BasicCommand baseCommand = new BasicCommand(inputPhrases);
            baseCommand.AddTerms("0", "1");
            baseCommand.AddTerms("2", "3");

            List<string> commands = baseCommand.GetCommands();
            Assert.AreEqual(8, commands.Count);
        }
    }
}

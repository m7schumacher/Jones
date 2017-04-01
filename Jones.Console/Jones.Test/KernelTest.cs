using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Jones.Domain.Phrases;

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

            ComplexPhrase baseCommand = new ComplexPhrase(inputPhrases);
            baseCommand.AddTerms("0", "1");
            baseCommand.AddTerms("2", "3");

            List<string> commands = baseCommand.GeneratePhrases();
            Assert.AreEqual(8, commands.Count);
        }
    }
}

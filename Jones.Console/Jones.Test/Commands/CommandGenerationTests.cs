using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jones.Domain.Phrases;
using Jones.Domain.Extensions;
using Jones.Domain;
using System.Collections.Generic;

namespace Jones.Test.Commands
{
    [TestClass]
    public class CommandGenerationTests
    {
        [TestMethod]
        public void TestBasicGeneration()
        {
            string[] subjects = new string[]
            {
                "weather", "wind", "rain"
            };

            SimplePhrase command = PhraseGenerator.HowDoing(false, subjects);
            List<string> phrases = command.GeneratePhrases();

            int expectedCount = BasePhrases.HowDoing.Length * subjects.Length;
            Assert.AreEqual(expectedCount, phrases.Count);
        }

        #region Take Tests

        [TestMethod]
        public void TestStringTakeLeft()
        {
            string example = "How does" + Constants.Delimeter + "do it look";

            string actual = example.TakeLeft();
            string expected = "How does it look";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestStringTakeRight()
        {
            string example = "How does" + Constants.Delimeter + "do it look";

            string actual = example.TakeRight();
            string expected = "How do it look";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestTakeAllLeft()
        {
            string[] inputs = new string[]
            {
                "How does:do it look",
                "What does:do this:they do"
            };

            string[] expected = new string[]
            {
                "How does it look",
                "What does this do"
            };

            string[] actual = inputs.TakeAllLeft();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestTakeAllRight()
        {
            string[] inputs = new string[]
            {
                "How does:do it:they look",
                "What does:do this:they do"
            };

            string[] expected = new string[]
            {
                "How do they look",
                "What do they do"
            };

            string[] actual = inputs.TakeAllRight();
            CollectionAssert.AreEqual(expected, actual);
        }

        #endregion
    }
}

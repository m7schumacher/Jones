using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jones.Domain.Internal.Tags;
using Jones.Domain.Phrases;
using System.Collections.Generic;

namespace Jones.Test.Internal
{
    [TestClass]
    public class ReflexTests
    {
        [TestMethod]
        public void TestBasicReflex()
        {
            string testSubject = "weather";

            ReflexMethod method = new ReflexMethod("-HowDoingSingle('" + testSubject + "')", testSubject);
            var phrases = method.Phrases;

            List<string> generatedPhrases = PhraseGenerator.HowDoingSingle(testSubject).GeneratePhrases();
            generatedPhrases.Add(testSubject);

            CollectionAssert.AreEqual(generatedPhrases.ToArray(), phrases);
        }
    }
}

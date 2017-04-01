using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jones.Domain.Internal.Tags;
using Jones.Domain.Extensions;
using System.Collections.Generic;

namespace Jones.Test.Internal
{
    internal class DeepBlock
    {
        [Adjectives("look", "feel")]
        public string Color { get; set; }

        public ComplexBlock Block { get; set; }
    }

    internal class ComplexBlock
    {
        [Adjectives("deep")]
        public int Depth { get; set; }
        
        public SimpleBlock Block { get; set; }
    }

    internal class SimpleBlock
    {
        [Adjectives("tall", "towering")]
        public int Height { get; set; }

        [Adjectives("wide", "stretching")]
        public int Width { get; set; }
    }

    [TestClass]
    public class EntityTests
    {
        [TestMethod]
        public void TestSimpleEntity()
        {
            SimpleBlock block = new SimpleBlock();
            Dictionary<string, string[]> result = block.GetTags();

            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.ContainsKey("Height"));
            Assert.IsTrue(result.ContainsKey("Width"));
            Assert.AreEqual(2, result["Height"].Length);
            Assert.AreEqual(2, result["Width"].Length);
        }

        [TestMethod]
        public void TestComplexEntity()
        {
            ComplexBlock block = new ComplexBlock();
            Dictionary<string, string[]> result = block.GetTags();

            Assert.AreEqual(3, result.Count);
            Assert.IsTrue(result.ContainsKey("Depth"));
            Assert.AreEqual(1, result["Depth"].Length);
            Assert.IsTrue(result.ContainsKey("Block.Height"));
            Assert.IsTrue(result.ContainsKey("Block.Width"));
            Assert.AreEqual(2, result["Block.Height"].Length);
            Assert.AreEqual(2, result["Block.Width"].Length);
        }

        [TestMethod]
        public void TestDeepEntity()
        {
            DeepBlock block = new DeepBlock();
            Dictionary<string, string[]> result = block.GetTags();

            Assert.AreEqual(4, result.Count);

            Assert.IsTrue(result.ContainsKey("Color"));
            Assert.AreEqual(2, result["Color"].Length);

            Assert.IsTrue(result.ContainsKey("Block.Depth"));
            Assert.AreEqual(1, result["Block.Depth"].Length);

            Assert.IsTrue(result.ContainsKey("Block.Block.Height"));
            Assert.IsTrue(result.ContainsKey("Block.Block.Width"));
            Assert.AreEqual(2, result["Block.Block.Height"].Length);
            Assert.AreEqual(2, result["Block.Block.Width"].Length);
        }
    }
}

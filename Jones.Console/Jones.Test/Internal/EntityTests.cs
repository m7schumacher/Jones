using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jones.Domain.Internal.Tags;
using Jones.Domain.Extensions;
using System.Collections.Generic;
using Jones.Domain;
using Jones.Cells.Weather;
using Jones.Domain.External.Weather;
using Jones.Home;

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
            TagCollection result = block.GetTags();

            Assert.AreEqual(2, result.Tags.Count);
            Assert.IsTrue(result.ContainsPath("Height"));
            Assert.IsTrue(result.ContainsPath("Width"));
            Assert.AreEqual(2, result["Height"].Adjectives.Length);
            Assert.AreEqual(2, result["Width"].Adjectives.Length);
        }

        [TestMethod]
        public void TestComplexEntity()
        {
            ComplexBlock block = new ComplexBlock();
            TagCollection result = block.GetTags();

            Assert.AreEqual(3, result.Tags.Count);
            Assert.IsTrue(result.ContainsPath("Depth"));
            Assert.AreEqual(1, result["Depth"].Adjectives.Length);
            Assert.IsTrue(result.ContainsPath("Block" + Constants.Delimeter + "Height"));
            Assert.IsTrue(result.ContainsPath("Block" + Constants.Delimeter + "Width"));
            Assert.AreEqual(2, result["Block" + Constants.Delimeter + "Height"].Adjectives.Length);
            Assert.AreEqual(2, result["Block" + Constants.Delimeter + "Width"].Adjectives.Length);
        }

        [TestMethod]
        public void TestDeepEntity()
        {
            WeatherCell cell = new WeatherCell();
            CurrentWeather weather = (CurrentWeather)cell.Pool.Entities[0];

            TagCollection coll = weather.GetTags();

            DeepBlock block = new DeepBlock();
            TagCollection result = block.GetTags();

            Assert.AreEqual(4, result.Tags.Count);

            Assert.IsTrue(result.ContainsPath("Color"));
            Assert.AreEqual(2, result["Color"].Adjectives.Length);

            Assert.IsTrue(result.ContainsPath("Block" + Constants.Delimeter + "Depth"));
            Assert.AreEqual(1, result["Block" + Constants.Delimeter + "Depth"].Adjectives.Length);

            Assert.IsTrue(result.ContainsPath("Block" + Constants.Delimeter + "Block" + Constants.Delimeter + "Height"));
            Assert.IsTrue(result.ContainsPath("Block" + Constants.Delimeter + "Block" + Constants.Delimeter + "Width"));
            Assert.AreEqual(2, result["Block" + Constants.Delimeter + "Block" + Constants.Delimeter + "Height"].Adjectives.Length);
            Assert.AreEqual(2, result["Block" + Constants.Delimeter + "Block" + Constants.Delimeter + "Width"].Adjectives.Length);
        }
    }
}

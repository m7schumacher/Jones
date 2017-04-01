using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jones.Cells.Weather;

namespace Jones.Test.Cells.Weather
{
    [TestClass]
    public class WeatherTest
    {
        [TestMethod]
        public void TestWeatherSummary()
        {
            WeatherCell cell = new WeatherCell();
            string result = cell.Execute("weather");

            Assert.IsFalse(result.Contains("{"));
        }
    }
}

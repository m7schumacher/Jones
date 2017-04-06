using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jones.Cells.Weather;
using Jones.Domain;

namespace Jones.Test.Cells.Weather
{
    [TestClass]
    public class WeatherTest
    {
        [TestMethod]
        public void TestWeatherSummary()
        {
            WeatherCell cell = new WeatherCell();
            Command testCommand = new Command("weather");

            string result = cell.Execute(testCommand);

            Assert.IsFalse(result.Contains("{"));
        }
    }
}

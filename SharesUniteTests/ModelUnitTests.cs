using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shares.Models;
using Xunit;

namespace SharesUniteTests
{

    public class ModelUnitTests
    {
        [Fact]
        public void InsightSymbolUnit()
        { 
        Insight insight = new Insight();
            insight.symbol = "IBM";
            Assert.True(insight.symbol == "IBM");
        }

        [Fact]
        public void InsightOpenUnit()
        {
            Insight insight = new Insight();
            insight.open = 00.1;
            Assert.True(insight.open == 00.1);
        }

        [Fact]
        public void InsightHighUnit()
        {
            Insight insight = new Insight();
            insight.high = 00.1;
            Assert.True(insight.high == 00.1);
        }

        [Fact]
        public void InsightLowUnit()
        {
            Insight insight = new Insight();
            insight.low = 00.1;
            Assert.True(insight.low == 00.1);
        }
        [Fact]
        public void InsightPriceUnit()
        {
            Insight insight = new Insight();
            insight.price = 00.1;
            Assert.True(insight.price == 00.1);
        }

        [Fact]
        public void InsightVolumeUnit()
        {
            Insight insight = new Insight();
            insight.volume = 00.1;
            Assert.True(insight.volume == 00.1);
        }

        [Fact]
        public void InsightlatesttradingdayUnit()
        {
            Insight insight = new Insight();
            insight.date = "2021-11-01 19:55:08.4141372";
            Assert.True(insight.date == "2021-11-01 19:55:08.4141372");
        }

        [Fact]
        public void InsightPCUnit()
        {
            Insight insight = new Insight();
            insight.pc = "2021-11-01 19:55:08.4141372";
            Assert.True(insight.pc == "2021-11-01 19:55:08.4141372");
        }

        [Fact]
        public void InsightChangeUnit()
        {
            Insight insight = new Insight();
            insight.change = "Hello?";
            Assert.True(insight.change == "Hello?");
        }

        [Fact]
        public void InsightCPUnit()
        {
            Insight insight = new Insight();
            insight.cp = "Hello?";
            Assert.True(insight.cp == "Hello?");
        }

    }
}

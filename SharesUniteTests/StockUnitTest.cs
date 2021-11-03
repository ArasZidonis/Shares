using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shares.Models;

namespace SharesUniteTests
{
    public class StockUnitTest
    {
        [Fact]
        public void PostShare_ShareId_UnitTest()
        {
           Stock stock = new Stock();
            stock.shareId = 1;
            Assert.True(stock.shareId == 1);
        }

        [Fact]
        public void PostShare_ShareName_UnitTest()
        {
            Stock stock = new Stock();
            stock.shareName = "GameStop";
            Assert.True(stock.shareName == "GameStop");
        }
        [Fact]
        public void PostShare_ShareSymbol_UnitTest()
        {
            Stock stock = new Stock();
            stock.shareSymbol = "Gme";
            Assert.True(stock.shareSymbol == "Gme");
        }
        [Fact]
        public void PostShare_boughtPrice_UnitTest()
        {
            Stock stock = new Stock();
            stock.boughtPrice = 15;
            Assert.True(stock.boughtPrice == 15);
        }

        [Fact]
        public void PostShare_stocks_UnitTest()
        {
            Stock stock = new Stock();
            stock.stocks = 15.1;
            Assert.True(stock.stocks == 15.1);
        }


        [Fact]
        public void PostShare_Date_UnitTest()
        {
            Stock stock = new Stock();
            stock.date = DateTime.Now;
            var date = stock.date;
            Assert.True(stock.date == date);
        }

        [Fact]
        public void PostShare_userid_UnitTest()
        {
            Stock stock = new Stock();
            stock.userid = 15;
            Assert.True(stock.userid == 15);
        }

        [Fact]
        public void PostShare_boughtValue_UnitTest()
        {
            Stock stock = new Stock();
            stock.boughtValue = 15.1;
            Assert.True(stock.boughtValue == 15.1);
        }

        [Fact]
        public void PostShare_actualValue_UnitTest()
        {
            Stock stock = new Stock();
            stock.actualValue = 15.1;
            Assert.True(stock.actualValue == 15.1);
        }

        [Fact]
        public void PostShare_profit_UnitTest()
        {
            Stock stock = new Stock();
            stock.profit = 15.1;
            Assert.True(stock.profit == 15.1);
        }

    }
}

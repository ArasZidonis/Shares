using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shares.Models;

namespace SharesUniteTests
{
    public class PostShareUnitTest
    {

        [Fact]
        public void PostShareShareNameUnitTest()
        {
            PostShare postShare = new PostShare();
            postShare.shareName = "IBM";
            Assert.True(postShare.shareName == "IBM");
        }
        [Fact]
        public void PostShare_ShareSymbol_UnitTest()
        {
            PostShare postShare = new PostShare();
            postShare.shareSymbol = "AXP";
            Assert.True(postShare.shareSymbol == "AXP");
        }

        [Fact]
        public void PostShare_BoughtPrice_UnitTest()
        {
            PostShare postShare = new PostShare();
            postShare.boughtPrice = 00.1;
            Assert.True(postShare.boughtPrice == 00.1);
        }

        [Fact]
        public void PostShare_Stocks_UnitTest()
        {
            PostShare postShare = new PostShare();
            postShare.stocks = 00.1;
            Assert.True(postShare.stocks == 00.1);
        }

        [Fact]
        public void PostShare_Userid_UnitTest()
        {
            PostShare postShare = new PostShare();
            postShare.userid = 1;
            Assert.True(postShare.userid == 1);
        }

    }
}

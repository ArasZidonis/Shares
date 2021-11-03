using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shares.Models;

namespace SharesUniteTests
{
    public class UserUnitTest
    {
        [Fact]
        public void User_userid_UnitTest()
        {
            User user = new User();
            user.userid = 15;
            Assert.True(user.userid == 15);
        }

        [Fact]
        public void User_username_UnitTest()
        {
            User user = new User();
            user.username = "Hello?";
            Assert.True(user.username == "Hello?");
        }

        [Fact]
        public void User_password_UnitTest()
        {
            User user = new User();
            user.password = "Hello?";
            Assert.True(user.password == "Hello?");
        }

        [Fact]
        public void User_name_UnitTest()
        {
            User user = new User();
            user.name = "Hello?";
            Assert.True(user.name == "Hello?");
        }

        [Fact]
        public void User_surname_UnitTest()
        {
            User user = new User();
            user.surname = "Hello?";
            Assert.True(user.surname == "Hello?");
        }

        [Fact]
        public void User_email_UnitTest()
        {
            User user = new User();
            user.email = "Hello?";
            Assert.True(user.email == "Hello?");
        }


    }
}

using System;
using HangerMan;
using Xunit;

namespace HangerManTest
{
    public class StaticMethodTest
    {
        [Fact]
        public void ShouldReturnCurrentDate()
        {
          var dateProvider = new DateProvider();
            var today = dateProvider.TodaysDate();
            Assert.Equal("2021-02-22", today );

        }
    }

    public class Test
    {
        
    }
}
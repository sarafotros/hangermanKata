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
          var today =dateProvider.TodaysDate();
          Assert.Equal(today, DateTime.Today.Date.ToString());

        }
    }

    public class Test
    {
        
    }
}
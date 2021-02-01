using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Flurl.Http;
using HangerMan.ApiWordProvider;

namespace HangerManTest
{
   public class FlurlTest 
    {

        [Fact]
        public void LookAtFlurl()
        {
            var wordProvider = new ApiWordProvider();
            var result = wordProvider.Word;
        }
    }
}

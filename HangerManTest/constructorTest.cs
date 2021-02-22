using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HangerManTest
{
   public class ConstructorTest
    {
        [Fact] 
        public void Test()
        {
            var myClass = new MyClass();

            Assert.Equal(myClass.GetName(), null);
        }

        public class MyClass
        {
            private string myName = "naomi";
            public MyClass()
            {
                
            }

            public string GetName()
            {
                return myName;
            }
        }
    }
}

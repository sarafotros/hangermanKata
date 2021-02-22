using System;
using System.Collections.Generic;
using System.Linq;

namespace HangerMan
{
    public class RandomWordProvider : IWordProvider
    {
        public string Word 
        { 
            get
            {
                Random r = new Random();

                var randomIndex = r.Next(0, words.Count);
                return words[randomIndex]; 
            } 
        
        }

        private List<string> words = new List<string>
        {
            "bat",
            "cat",
            "rat",
            "sat"
        };



    }
}
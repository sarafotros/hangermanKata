using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;

namespace HangerMan
{
    public class ApiWordProvider : IWordProvider
    {
        public string Word
        {
            get
            {
                var result = "http://newsapi.org/v2/everything?q=tesla&from=2021-02-08&sortBy=publishedAt&apiKey=acdb4d1d0609489ebb953aaf133d39fb"
                    .GetJsonAsync<NewsResponse>()
                    .GetAwaiter()
                    .GetResult();

                Random r = new Random();
                var randomIndex = r.Next(0, result.Articles.Count());
               
                var randomArticle = result.Articles[randomIndex];

                var articleWordArray = randomArticle.Description.Split(' ');

                var randomWordIndex = r.Next(0, articleWordArray.Length);

                var randomWord = articleWordArray[randomWordIndex];

                return randomWord;
            }
        }
    }

    public class NewsResponse
    {
        [JsonProperty("articles")]
        public List<Article> Articles
        {
            get;
            set;
        }
    }

    public class Article
    {
        [JsonProperty("description")]
        public string Description
        {
            get;
            set; 
        }
    }


}

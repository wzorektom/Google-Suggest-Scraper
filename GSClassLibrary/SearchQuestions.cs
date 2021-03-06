﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibrary
{
    public class SearchQuestions : GoogleSearchAPI
    {
        private static readonly List<GoogleQuestions> list = new List<GoogleQuestions>();
        readonly List<GoogleQuestions> Google_Questions = list;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<List<GoogleQuestions>> GetDataAsync(string query)
        {
            string result1 = String.Empty;      
            Google_Questions.Clear();

            using (HttpClient client = new HttpClient())
            {
                string[] questions = { "Why", "Who", "When", "How", "What", "Where", "Which", "Are", "Can", "Will", "Does", "Do" };

                foreach (var question in questions)
                {
                    result1 = await client.GetStringAsync(QueryPath + question + " " + query + " ");

                    XDocument doc = XDocument.Parse(result1);

                    var suggestionsForQuestions = from suggestion in doc.Descendants("CompleteSuggestion")
                                                  select new GoogleQuestions
                                                  {

                                                      Questions = suggestion.Element("suggestion").Attribute("data").Value
                                                  };

                    Google_Questions.AddRange(suggestionsForQuestions);
                }

            }
            return Google_Questions;
        }
    }
}

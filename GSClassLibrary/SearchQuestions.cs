using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibrary
{
    public class SearchQuestions : GoogleSearchAPI
    {
        List<GoogleQuestions> Google_Questions = new List<GoogleQuestions>();

        public async Task<List<GoogleQuestions>> GetDataAsync(string query)
        {
            string result1 = String.Empty;      
            Google_Questions.Clear();

            using (HttpClient client = new HttpClient())
            {
                string[] questions = { "Why", "Who", "When", "How", "What", "Where", "Which", "Are", "Can", "Will", "Does", "Do" };

                foreach (var question in questions)
                {
                    result1 = await client.GetStringAsync(searchString + question + " " + query + " ");

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

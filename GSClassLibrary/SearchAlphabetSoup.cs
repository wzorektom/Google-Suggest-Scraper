using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibrary
{
    public class SearchAlphabetSoup : GoogleSearchAPI
    {
        private static readonly List<GoogleAlphabetSoup> list = new List<GoogleAlphabetSoup>();
        readonly List<GoogleAlphabetSoup> Google_Soup = list;

        /// <summary>
        /// Itterate through each letter of the alphabet with the given search query
        /// </summary>
        /// <param name="query">The search word typed by the user</param>
        /// <returns></returns>
        public async Task<List<GoogleAlphabetSoup>> GetDataAsync(string query)
        {
            Google_Soup.Clear();
            string result = String.Empty;

            using (HttpClient client = new HttpClient())
            {

                result = await client.GetStringAsync(QueryPath + query + " ");
                XDocument doc1 = XDocument.Parse(result);

                var suggestionsNoAlphabet = from suggestion in doc1.Descendants("CompleteSuggestion")
                                            select new GoogleAlphabetSoup
                                            {
                                                AlphabetSoup = suggestion.Element("suggestion").Attribute("data").Value
                                            };
                Google_Soup.AddRange(suggestionsNoAlphabet);


                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + query + " " + c);
                    XDocument doc = XDocument.Parse(result);

                    var suggestionsAlphabet = from suggestion in doc.Descendants("CompleteSuggestion")
                                              select new GoogleAlphabetSoup
                                              {
                                                  AlphabetSoup = suggestion.Element("suggestion").Attribute("data").Value
                                              };
                    Google_Soup.AddRange(suggestionsAlphabet);
                    
                  
                }

            }
            return Google_Soup;
        }

    }
}

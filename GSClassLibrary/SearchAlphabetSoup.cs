using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibrary
{
    public class SearchAlphabetSoup : GoogleSearchAPI
    {
        
        List<GoogleAlphabetSoup> Google_Soup = new List<GoogleAlphabetSoup>();




        public async Task<List<GoogleAlphabetSoup>> GetDataAsync(string query)
        {
            Google_Soup.Clear();
            string result = String.Empty;

            using (HttpClient client = new HttpClient())
            {

                result = await client.GetStringAsync(searchString + query + " ");
                XDocument doc1 = XDocument.Parse(result);

                var suggestionsNoAlphabet = from suggestion in doc1.Descendants("CompleteSuggestion")
                                            select new GoogleAlphabetSoup
                                            {
                                                AlphabetSoup = suggestion.Element("suggestion").Attribute("data").Value
                                            };
                Google_Soup.AddRange(suggestionsNoAlphabet);


                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + query + " " + c);
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

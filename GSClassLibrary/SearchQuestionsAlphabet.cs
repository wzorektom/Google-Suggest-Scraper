using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibrary
{
    public class SearchQuestionsAlphabet : GoogleSearchAPI
    {
        List<GoogleQuestionsAlphabet> Google_Questions_alpha = new List<GoogleQuestionsAlphabet>();

        string[] questions = { "Why", "Who", "When", "How", "What", "Where", "Which", "Are", "Can", "Will", "Does", "Do" };

        public async Task<List<GoogleQuestionsAlphabet>> GetDataAsync(string query)
        {
            string result = String.Empty;
            Google_Questions_alpha.Clear();




            // How * myword
            using (HttpClient client = new HttpClient())
            {
                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + "How " + c + " " + query);

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions = from suggestion in doc.Descendants("CompleteSuggestion")
                                                  select new GoogleQuestionsAlphabet
                                                  {
                                                      QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                  };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions);
                }
            }


            result = String.Empty;
            // How to * a myword
            using (HttpClient client = new HttpClient())
            {
                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + "How to " + c + " " + "a " + query);

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions2 = from suggestion in doc.Descendants("CompleteSuggestion")
                                                   select new GoogleQuestionsAlphabet
                                                   {
                                                       QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                   };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions2);
                }
            }



            result = String.Empty;
            // How does a myword *
            using (HttpClient client = new HttpClient())
            {
                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + "How does a " + query + " " + c);

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions3 = from suggestion in doc.Descendants("CompleteSuggestion")
                                                   select new GoogleQuestionsAlphabet
                                                   {
                                                       QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                   };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions3);
                }
            }



            result = String.Empty;
            // What * myword
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + "What " + c + " " + query);

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions4 = from suggestion in doc.Descendants("CompleteSuggestion")
                                                   select new GoogleQuestionsAlphabet
                                                   {
                                                       QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                   };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions4);
                }
            }



            result = String.Empty;
            // Can * myword
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + "Can " + c + " " + query);

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions5 = from suggestion in doc.Descendants("CompleteSuggestion")
                                                   select new GoogleQuestionsAlphabet
                                                   {
                                                       QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                   };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions5);
                }
            }





            result = String.Empty;
            // Is * myword
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + "Is " + c + " " + query);

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions6 = from suggestion in doc.Descendants("CompleteSuggestion")
                                                   select new GoogleQuestionsAlphabet
                                                   {
                                                       QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                   };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions6);
                }
            }





            result = String.Empty;
            // Does my myword *
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + "Does my " + query + " " + c);

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions7 = from suggestion in doc.Descendants("CompleteSuggestion")
                                                   select new GoogleQuestionsAlphabet
                                                   {
                                                       QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                   };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions7);
                }
            }





            result = String.Empty;
            // Does a myword *
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + "Does a " + query + " " + c);

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions8 = from suggestion in doc.Descendants("CompleteSuggestion")
                                                   select new GoogleQuestionsAlphabet
                                                   {
                                                       QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                   };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions8);
                }
            }




            result = String.Empty;
            // Best myword for *
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + "Best " + query + " for " + c);

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions9 = from suggestion in doc.Descendants("CompleteSuggestion")
                                                   select new GoogleQuestionsAlphabet
                                                   {
                                                       QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                   };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions9);
                }
            }




            result = String.Empty;
            // Top myword *
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + "Top " + query + " " + c);

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions10 = from suggestion in doc.Descendants("CompleteSuggestion")
                                                    select new GoogleQuestionsAlphabet
                                                    {
                                                        QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                    };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions10);
                }
            }




            result = String.Empty;
            // Top 10 myword *
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + "Top 10 " + query + " " + c);

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions11 = from suggestion in doc.Descendants("CompleteSuggestion")
                                                    select new GoogleQuestionsAlphabet
                                                    {
                                                        QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                    };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions11);
                }
            }




            result = String.Empty;
            // Top 15 myword *
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + "Top 15 " + query + " " + c);

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions11a = from suggestion in doc.Descendants("CompleteSuggestion")
                                                     select new GoogleQuestionsAlphabet
                                                     {
                                                         QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                     };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions11a);
                }
            }




            result = String.Empty;
            // Top 5 myword *
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + "Top 5 " + query + " " + c);

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions11b = from suggestion in doc.Descendants("CompleteSuggestion")
                                                     select new GoogleQuestionsAlphabet
                                                     {
                                                         QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                     };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions11b);
                }
            }




            result = String.Empty;
            // Best myword *
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + "Best " + query + " " + c);

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions12 = from suggestion in doc.Descendants("CompleteSuggestion")
                                                    select new GoogleQuestionsAlphabet
                                                    {
                                                        QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                    };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions12);
                }
            }




            result = String.Empty;
            // myword or *
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + query + " or " + c);

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions13 = from suggestion in doc.Descendants("CompleteSuggestion")
                                                    select new GoogleQuestionsAlphabet
                                                    {
                                                        QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                    };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions13);
                }
            }




            result = String.Empty;
            // myword vs *
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + query + " vs " + c);

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions14 = from suggestion in doc.Descendants("CompleteSuggestion")
                                                    select new GoogleQuestionsAlphabet
                                                    {
                                                        QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                    };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions14);
                }
            }




            result = String.Empty;
            // * or myword
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + c + " or " + query);

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions15 = from suggestion in doc.Descendants("CompleteSuggestion")
                                                    select new GoogleQuestionsAlphabet
                                                    {
                                                        QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                    };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions15);
                }
            }




            result = String.Empty;
            // * vs myword
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + c + " vs " + query);

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions16 = from suggestion in doc.Descendants("CompleteSuggestion")
                                                    select new GoogleQuestionsAlphabet
                                                    {
                                                        QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                    };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions16);
                }
            }




            result = String.Empty;
            // myword * reviews
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + query + " " + c + " reviews");

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions17 = from suggestion in doc.Descendants("CompleteSuggestion")
                                                    select new GoogleQuestionsAlphabet
                                                    {
                                                        QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                    };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions17);
                }
            }




            result = String.Empty;
            // * myword reviews
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + c + " " + query + " reviews");

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions18 = from suggestion in doc.Descendants("CompleteSuggestion")
                                                    select new GoogleQuestionsAlphabet
                                                    {
                                                        QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                    };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions18);
                }
            }




            result = String.Empty;
            // myword * comparison
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + query + " " + c + " comparison");

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions19 = from suggestion in doc.Descendants("CompleteSuggestion")
                                                    select new GoogleQuestionsAlphabet
                                                    {
                                                        QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                    };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions19);
                }
            }




            result = String.Empty;
            // * myword comparison
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(searchString + c + " " + query + " comparison");

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions20 = from suggestion in doc.Descendants("CompleteSuggestion")
                                                    select new GoogleQuestionsAlphabet
                                                    {
                                                        QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                    };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions20);
                }
            }



            return Google_Questions_alpha;
        }





    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibrary
{
    public class SearchQuestionsAlphabet : GoogleSearchAPI
    {
        readonly List<GoogleQuestionsAlphabet> Google_Questions_alpha = new List<GoogleQuestionsAlphabet>();
        //private readonly string[] questions = { "Why", "Who", "When", "How", "What", "Where", "Which", "Are", "Can", "Will", "Does", "Do" };

        // Clear the results
        //string result = String.Empty;


       


        public async Task<List<GoogleQuestionsAlphabet>> GetDataAsync(string query)
        {

            // TODO encapsulate the results string - make full property and set to empty

            // Clear results
            string result = string.Empty;
            // Clear the list 
            Google_Questions_alpha.Clear();


            // Perform search - Substitute the * by an alphabet letter plus a search phrase in evey combination


            #region How * myword

            // How * myword
            using (HttpClient client = new HttpClient())
            {
                // Loop throug the alphabet
                for (char c = 'a'; c <= 'z'; c++)
                {
                    // Get the XML results
                    result = await client.GetStringAsync(QueryPath + "How " + c + " " + query);

                    // Parse the results
                    XDocument doc = XDocument.Parse(result);

                    // Extract usefull information
                    var suggestionsForQuestions = from suggestion in doc.Descendants("CompleteSuggestion")
                                                  select new GoogleQuestionsAlphabet
                                                  {
                                                      QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                  };
                    // Add the collection of extracted results to the list - returned at the end of this class
                    Google_Questions_alpha.AddRange(suggestionsForQuestions);
                }
            }

            

            #endregion

            #region How to * a myword

            // How to * a myword
            using (HttpClient client = new HttpClient())
            {
                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + "How to " + c + " " + "a " + query);

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

            #endregion

            #region How does a myword *

            // How does a myword *
            using (HttpClient client = new HttpClient())
            {
                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + "How does a " + query + " " + c);

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

            #endregion

            #region What * myword

            // What * myword
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + "What " + c + " " + query);

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

            #endregion

            #region Can * myword

            // Can * myword
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + "Can " + c + " " + query);

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

            #endregion

            #region Is * myword

            // Is * myword
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + "Is " + c + " " + query);

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

            #endregion

            #region Does my myword *

            // Does my myword *
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + "Does my " + query + " " + c);

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

            #endregion

            #region Does a myword *

            // Does a myword *
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + "Does a " + query + " " + c);

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

            #endregion

            #region Best myword for *

            // Best myword for *
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + "Best " + query + " for " + c);

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

            #endregion

            #region Top myword *

            // Top myword *
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + "Top " + query + " " + c);

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

            #endregion

            #region Top 10 myword *

            // Top 10 myword *
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + "Top 10 " + query + " " + c);

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

            #endregion

            #region Top 15 myword *

            // Top 15 myword *
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + "Top 15 " + query + " " + c);

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

            #endregion

            #region Top 5 myword *

            // Top 5 myword *
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + "Top 5 " + query + " " + c);

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

            #endregion

            #region Best myword *

            // Best myword *
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + "Best " + query + " " + c);

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

            #endregion

            #region myword or *

            // myword or *
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + query + " or " + c);

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

            #endregion

            #region myword vs *

            // myword vs *
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + query + " vs " + c);

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

            #endregion

            #region * or myword

            // * or myword
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + c + " or " + query);

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

            #endregion

            #region * vs myword

            // * vs myword
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + c + " vs " + query);

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

            #endregion

            #region myword * reviews

            // myword * reviews
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + query + " " + c + " reviews");

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

            #endregion

            #region * myword reviews

            // * myword reviews
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + c + " " + query + " reviews");

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

            #endregion

            #region myword * comparison

            // myword * comparison
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + query + " " + c + " comparison");

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

            #endregion

            #region * myword comparison

            // * myword comparison
            using (HttpClient client = new HttpClient())
            {

                for (char c = 'a'; c <= 'z'; c++)
                {
                    result = await client.GetStringAsync(QueryPath + c + " " + query + " comparison");

                    XDocument doc = XDocument.Parse(result);
                    var suggestionsForQuestions20 = from suggestion in doc.Descendants("CompleteSuggestion")
                                                    select new GoogleQuestionsAlphabet
                                                    {
                                                        QuestionsAlphabet = suggestion.Element("suggestion").Attribute("data").Value
                                                    };
                    Google_Questions_alpha.AddRange(suggestionsForQuestions20);
                }
            }

            #endregion




            // Return the list of questions
            return Google_Questions_alpha;
        }





    }
}

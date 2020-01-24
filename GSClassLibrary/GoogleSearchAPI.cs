namespace ClassLibrary
{
    public class GoogleSearchAPI
    {
        private const string _googleQueryPath = "http://google.com/complete/search?output=toolbar&q=";

        public static string QueryPath { get; } = _googleQueryPath; // For UK


        //public static string searchString1 { get; } = "http://suggestqueries.google.com/complete/search?output=toolbar&hl=en&q=";
    }
}

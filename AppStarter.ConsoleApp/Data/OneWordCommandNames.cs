using Console.Lib;

namespace AppStarter.ConsoleApp
{
    public class OneWordCommandNames : IOneWordNames
    {
        public string[] GetInstance()
        {
            return new string []
            {
                "Help".ToLowerInvariant()
                , "Clear".ToLowerInvariant()
                , "Exit".ToLowerInvariant()
                , "Start".ToLowerInvariant()
            };
        }
    }
}
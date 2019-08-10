using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace app.Extensions
{
    public static class BracketedStringHelper
    {
        public static string ToStringBracketed(this IEnumerable<Match> colletion)
        {
            string bracketedArray = string.Empty;
            colletion.ToList().ForEach(player => bracketedArray += player);

            return bracketedArray;
        }

        public static MatchCollection MatchPlayers(this string bracketedArray)
        {
            var pattern = @"\[(.*?)\]";
            var players = Regex.Matches(bracketedArray, pattern);

            return players;
        }    

        public static string[] GetPlayerGame(this string bracketedPlayer)
        {
            return bracketedPlayer.Replace("[", string.Empty)
                                    .Replace("]", string.Empty)
                                    .Replace("'", string.Empty)
                                    .Replace("\"", string.Empty)
                                    .Split(',');
        }               
    }
}
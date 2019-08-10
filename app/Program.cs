using System;
using System.Text.RegularExpressions;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            var bracketedArrayTournament = GetBracketedArrayTournament();

            var tournament = new RpsTournament(bracketedArrayTournament);

            var result = tournament.RpsTournamentWinner();

            Console.WriteLine($"Vencedor: {result}");
        }

        private static string GetBracketedArrayTournament()
        {
            return @"[
                [   
                    [ ['Armando', 'P'], ['Dave', 'S'] ],      
                    [ ['Richard', 'R'], ['Michael', 'S'] ]
                ],
                [
                    [ ['Allen', 'S'], ['Omer', 'P'] ],
                    [ ['David E.', 'R'], ['Richard X.', 'P'] ] 
                ]
            ]";
        }
    }
}

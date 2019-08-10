using System;
using System.Text.RegularExpressions;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            var rpsGame = new RpsGame();
            var winner = rpsGame.RpsGameWinner("[ [\"Armando\", \"P\"], [\"Dave\", \"S\"] ]");

            Console.WriteLine($"Vencedor: {winner}");

            var tournament = new RpsTournament(bracketedArrayTournament);

            var result = tournament.RpsTournamentWinner();

            Console.WriteLine($"Vencedor: {result}");
        }

        private const string bracketedArrayTournament = 
            @"[
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

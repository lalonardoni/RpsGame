using System;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            var rpsRule = new RpsRule();

            var rpsGame = new RpsGame(rpsRule);
            var winner = rpsGame.RpsGameWinner("[ [\"Armando\", \"P\"], [\"Dave\", \"S\"] ]");

            Console.WriteLine($"Vencedor: {winner}");

            var tournament = new RpsTournament(rpsGame);

            var result = tournament.BuildTournament(bracketedArrayTournament)
                                        .RpsTournamentWinner();

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

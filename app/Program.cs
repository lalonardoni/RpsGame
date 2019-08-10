using System;
using Microsoft.Extensions.DependencyInjection;

namespace app
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IRpsRule, RpsRule>()
                .AddSingleton<IRpsGame, RpsGame>()
                .AddSingleton<IRpsTournamentBuilder, RpsTournament>()
                .AddSingleton<IRpsTournament, RpsTournament>()
                .BuildServiceProvider();

            var rpsGame = serviceProvider.GetService<IRpsGame>();
            var gameWinner = rpsGame.RpsGameWinner("[ [\"Armando\", \"P\"], [\"Dave\", \"S\"] ]");

            Console.WriteLine($"Vencedor: {gameWinner}");

            var rpsTournament = serviceProvider.GetService<IRpsTournamentBuilder>();
            var rpsTournamentWinner = rpsTournament.BuildTournament(bracketedArrayTournament)
                                                        .RpsTournamentWinner();

            Console.WriteLine($"Vencedor: {rpsTournamentWinner}");
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

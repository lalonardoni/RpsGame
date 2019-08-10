using System;
using app.Extensions;

namespace app
{
    public class RpsGame : IRpsGame
    {
        private IRpsRule rule;

        public RpsGame()
        {
            this.rule = new RpsRule();
        }
        public string RpsGameWinner(string bracketedGameArray)
        {
            return this.RpsGameWinner<string>(bracketedGameArray);
        }
        public T RpsGameWinner<T>(string bracketedGameArray)
        {
            var players = bracketedGameArray.MatchPlayers();

            var player1 = new Player($"{players[0]}");
            var player2 = new Player($"{players[1]}");

            var player = rule.Winner(player1, player2);

            if(typeof(T) == typeof(string))
            {
                return (T)Convert.ChangeType(player.ToString(), typeof(T));
            }

            return (T)Convert.ChangeType(player, typeof(T));
        }
    }
}
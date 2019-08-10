using System.Linq;
using app.Extensions;

namespace app
{
    public class RpsTournament
    {
        private RpsTournament[] tournamentsChildren;
        private string bracketedArray;
        private RpsGame rpsGame;

        public RpsTournament(string bracketedArray)
        {
            this.rpsGame = new RpsGame();
            this.bracketedArray = bracketedArray;

            BuildTournament(bracketedArray);
        }

        public string RpsTournamentWinner()
        {
            return this.RpsTournamentWinner<string>();
        }

        public T RpsTournamentWinner<T>()
        {
            if(this.tournamentsChildren != null)
            {
                var player1 = this.tournamentsChildren[0].RpsTournamentWinner<T>();
                var player2 = this.tournamentsChildren[1].RpsTournamentWinner<T>();

                this.bracketedArray = $"{player1},{player2}";
            }

            return (T)this.rpsGame.RpsGameWinner<T>(bracketedArray);
        }

        private void BuildTournament(string bracketedArray)
        {
            var players = bracketedArray.MatchPlayers();

            if(players.Count%2 == 0)
            {
                if (players.Count > 2)
                {
                    int centerIndex = players.Count / 2;
                    this.tournamentsChildren = new RpsTournament[2];

                    this.tournamentsChildren[0] = new RpsTournament(BracketedStringHelper.ToStringBracketed(players.Take(centerIndex)));
                    this.tournamentsChildren[1] = new RpsTournament(BracketedStringHelper.ToStringBracketed(players.TakeLast(centerIndex)));
                }
            }
        }
    }
}
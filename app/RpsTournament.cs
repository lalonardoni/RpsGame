using System.Linq;
using app.Extensions;
using app.Exceptions;

namespace app
{
    public class RpsTournament : IRpsTournamentBuilder, IRpsTournament
    {
        private RpsTournament[] tournamentsChildren;
        private string bracketedArray;
        private IRpsGame rpsGame;

        public RpsTournament(IRpsGame rpsGame)
        {
            this.rpsGame = rpsGame;
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

        public IRpsTournament BuildTournament(string bracketedTournamentArray)
        {
            this.bracketedArray = bracketedTournamentArray;

            var players = bracketedTournamentArray.MatchPlayers();

            if(players.Count%2 == 0)
            {
                if (players.Count > 2)
                {
                    int centerIndex = players.Count / 2;
                    this.tournamentsChildren = new RpsTournament[2];

                    this.tournamentsChildren[0] = new RpsTournament(this.rpsGame);
                    this.tournamentsChildren[0].BuildTournament(BracketedStringHelper.ToStringBracketed(players.Take(centerIndex)));

                    this.tournamentsChildren[1] = new RpsTournament(this.rpsGame);
                    this.tournamentsChildren[1].BuildTournament(BracketedStringHelper.ToStringBracketed(players.TakeLast(centerIndex)));
                }
            }
            else
            {
                throw new WrongNumberOfPlayersError();
            }

            return this;
        }
    }
}
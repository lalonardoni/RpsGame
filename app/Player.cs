using System;
using app.Exceptions;
using app.Extensions;

namespace app
{
    public class Player
    {
        public Player(string bracketedPlayer)
        {
            this.PlayerGame = bracketedPlayer.GetPlayerGame();
        }
        public string Name 
        { 
            get {
                return PlayerGame[0].Trim();
            }
        }
        public SelectOption SelectedMove 
        { 
            get {
                    SelectOption strategy;

                    if (!Enum.TryParse(PlayerGame[1], true, out strategy))
                        throw new NoSuchStrategyError();

                    return strategy;
            }
        }

        private string[] _playerGame;
        public string[] PlayerGame 
        { 
            get
            {
                return _playerGame;
            }
            private set
            {
                if (value.Length != 2)
                    throw new WrongPlayerPatternError();

                _playerGame = value;
            } 
        }
        
        public override string ToString()
        {
            return $"['{this.Name}','{this.SelectedMove}']";
        }
    }
}
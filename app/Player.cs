using System;
using app.Exceptions;

namespace app
{
    public class Player
    {
        public Player(string bracketPlayer)
        {
            this.PlayerMove = bracketPlayer.Replace("[", string.Empty)
                                            .Replace("]", string.Empty)
                                            .Replace("'", string.Empty)
                                            .Replace("\"", string.Empty)
                                            .Split(',');
        }
        public string Name 
        { 
            get {
                return PlayerMove[0].Trim();
            }
        }
        public SelectOption SelectedMove 
        { 
            get {
                    SelectOption strategy;

                    if (!Enum.TryParse(PlayerMove[1], true, out strategy))
                        throw new NoSuchStrategyError();

                    return strategy;
            }
        }

        private string[] _playerMove;
        public string[] PlayerMove 
        { 
            get
            {
                return _playerMove;
            }
            set
            {
                if (value.Length != 2)
                    throw new WrongNumberOfPlayersError();

                _playerMove = value;
            } 
        }
        
        public override string ToString()
        {
            return $"['{this.Name}','{this.SelectedMove}']";
        }
    }
}
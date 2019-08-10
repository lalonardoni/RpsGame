using System;
using app.Exceptions;

namespace app
{
    public class Player
    {
        public Player(string bracketPlayer)
        {
            this.PlayerMove = bracketPlayer.Replace("[", string.Empty).Replace("]", string.Empty).Replace("'", string.Empty).Split(',');
        }
        public string Name 
        { 
            get {
                return PlayerMove[0];
            }
        }
        public SelectOption SelectedMove 
        { 
            get {
                if (IsValid(PlayerMove[1]))
                    return (SelectOption)Enum.Parse(typeof(SelectOption), PlayerMove[1]);
                else
                    throw new NoSuchStrategyError();
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

        private bool IsValid(string rps)
        {
            return true;
            // string valid = "RPS";
            // return valid.Contains(rps);
        }
    }
}
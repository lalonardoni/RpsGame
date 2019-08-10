namespace app
{
    public class RpsRule : IRpsRule
    {
        public Player Winner(Player player1, Player player2)
        {
            if(player1.SelectedMove != player2.SelectedMove)
            {
                switch (player1.SelectedMove)
                {
                    case SelectOption.R:
                        if(player2.SelectedMove == SelectOption.S)
                            return player1;
                        else return player2;
                    case SelectOption.S:
                        if(player2.SelectedMove == SelectOption.P)
                            return player1;
                        else return player2;
                    case SelectOption.P:
                        if(player2.SelectedMove == SelectOption.R)
                            return player1;
                        else return player2;                        
                    default: 
                        return player1;
                }
            }
            else
                return player1;
        }
    }
}
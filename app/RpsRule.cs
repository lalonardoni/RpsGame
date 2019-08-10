namespace app
{
    public class RpsRule : IRpsRule
    {
        public Player Winner(Player player1, Player player2)
        {
            if(player1.SelectedMove == player2.SelectedMove)
                return player1;

            switch (player1.SelectedMove)
            {
                case SelectOption.R:
                    return Winner(player1, player2, SelectOption.S);
                case SelectOption.S:
                    return Winner(player1, player2, SelectOption.P);
                case SelectOption.P:
                    return Winner(player1, player2, SelectOption.R);
                default: 
                    return player1;
            }
        }

        private Player Winner(Player player1, Player player2, SelectOption optionToCompare)
        {
            if(player2.SelectedMove == optionToCompare)
                return player1;
            
            return player2;
        }
    }
}
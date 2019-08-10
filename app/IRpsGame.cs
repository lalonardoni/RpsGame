namespace app
{
    public interface IRpsGame
    {
        /// <summary>
        /// Método rps_game_winner que executa o jogo e retorna o vencedor
        /// Há duas opções de tipo de retorno: Tipo Player ou String
        /// </summary>
        /// <param name="bracketedGameArray">String com o jogo (encode of rock-paper-scissors game as a list)</param>
        /// <response>Vencedor conforme tipo genérico que pode ser Player ou String</response>        
        T RpsGameWinner<T>(string bracketedGameArray);

        /// <summary>
        /// Método rps_game_winner que executa o jogo e retorna o vencedor        
        /// </summary>
        /// <param name="bracketedGameArray">String com o jogo (encode of rock-paper-scissors game as a list)</param>
        /// <response>Vencedor numa string</response>              
        string RpsGameWinner(string bracketedGameArray);
    }
}
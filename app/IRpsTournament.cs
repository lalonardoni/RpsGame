namespace app
{
    public interface IRpsTournament
    {
        /// <summary>
        /// Método rps_tournament_winner que executa o torneio e retorna o vencedor em uma string
        /// </summary>
        /// <response>Vencedor numa string</response>            
        string RpsTournamentWinner();

        /// <summary>
        /// Método rps_tournament_winner que executa o torneio e retorna o vencedor
        /// Há duas opções de tipo de retorno: Tipo Player ou String
        /// </summary>
        /// <response>Vencedor conforme tipo genérico que pode ser Player ou String</response> 
        T RpsTournamentWinner<T>();
    }
}
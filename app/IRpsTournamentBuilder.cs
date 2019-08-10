namespace app
{
    public interface IRpsTournamentBuilder
    {
        /// <summary>
        /// Este método constrói um torneio conforme o parâmetro string
        /// </summary>
        /// <param name="bracketedTournamentArray">string com o torneio (tournament encoded as a bracketed array)</param>
        /// <response>Instância do torneio</response> 
        IRpsTournament BuildTournament(string bracketedTournamentArray);
    }
}
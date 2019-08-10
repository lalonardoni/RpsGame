using app;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class RpsTournamentTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(torneio1, "[ ['Richard', 'R'] ]", Description = "Deve vencer o jogador Richard com a pedra")]
        [TestCase(torneio2, "[ ['David E.', 'S'] ]", Description = "Deve vencer o jogador David E. com a tesoura")]
        public void Deve_Vencer_Jogador_Conforme_Regras_Estabelecidas_no_Jogo_RPS(string bracketedTournamentArray, string expectedWinner)
        {
            var rpsTournament = new RpsTournament(bracketedTournamentArray);

            var expectedWinnerPlayer = new Player(expectedWinner);
            var winnerPlayer = rpsTournament.RpsTournamentWinner<Player>();

            Assert.AreEqual(winnerPlayer.Name, expectedWinnerPlayer.Name);
        }   

        private const string torneio1 = @"[
                [   
                    [ ['Armando', 'P'], ['Dave', 'S'] ],      
                    [ ['Richard', 'R'], ['Michael', 'S'] ]
                ],
                [
                    [ ['Allen', 'S'], ['Omer', 'P'] ],
                    [ ['David E.', 'R'], ['Richard X.', 'P'] ] 
                ]
            ]";          

        private const string torneio2 = @"[
                [   
                    [ ['Richard', 'R'], ['Dave', 'S'] ],      
                    [ ['Armando', 'P'], ['Michael', 'P'] ]
                ],
                [
                    [ ['Allen', 'P'], ['Omer', 'R'] ],
                    [ ['David E.', 'S'], ['Richard X.', 'P'] ] 
                ]
            ]";
    }
}
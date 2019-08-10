using app;
using app.Exceptions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class RpsTournamentTest
    {
        private IRpsTournamentBuilder rpsTournament;

        [SetUp]
        public void Setup()
        {
            var rpsRule = new RpsRule();
            var rpsGame = new RpsGame(rpsRule);

            rpsTournament = new RpsTournament(rpsGame);
        }

        [TestCase(torneio1, "[ ['Richard', 'R'] ]", Description = "Deve vencer o jogador Richard com a pedra")]
        [TestCase(torneio2, "[ ['David E.', 'S'] ]", Description = "Deve vencer o jogador David E. com a tesoura")]
        public void Deve_Vencer_Jogador_Conforme_Regras_Estabelecidas_no_Jogo_RPS(string bracketedTournamentArray, string expectedWinner)
        {
            var expectedWinnerPlayer = new Player(expectedWinner);
            var winnerPlayer = rpsTournament.BuildTournament(bracketedTournamentArray)
                                                .RpsTournamentWinner<Player>();

            Assert.AreEqual(winnerPlayer.Name, expectedWinnerPlayer.Name);
        }   

        [TestCase(torneio3)]
        public void Deve_Retornar_Excecao_Para_Torneios_Com_Chaves_Incompativeis(string bracketedTournamentArray)
        {
            Assert.That(() => rpsTournament.BuildTournament(bracketedTournamentArray).
                                                RpsTournamentWinner(), Throws.TypeOf<WrongNumberOfPlayersError>());
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

        private const string torneio3 = @"[
                [   
                    [ ['Richard', 'R'], ['Dave', 'S'] ],      
                    [ ['Armando', 'P'], ['Michael', 'P'] ]
                ],
                [
                    [ ['Allen', 'P'], ['Omer', 'R'] ],
                    [ ['David E.', 'S'], ['Richard X.', 'P'] ] 
                ],
                [
                    [ ['Allen', 'P'], ['Omer', 'R'] ],
                    [ ['David E.', 'S'], ['Richard X.', 'P'] ] 
                ]
            ]";            
    }
}
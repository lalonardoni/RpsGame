using app;
using NUnit.Framework;
using app.Exceptions;
using System;

namespace Tests
{
    [TestFixture]
    public class RpsGameTest
    {
        [SetUp]
        public void Setup()
        {
        }


        [TestCase("[ [\"Armando\", \"P\"], [\"Dave\", \"S\"], [\"Joaozinho\", \"R\"] ]")]
        [TestCase("[ [\"Armando\", \"P\"] ]")]
        public void Deve_Retornar_Excecao_Caso_Numero_Jogadores_Diferente_De_Dois(string bracketedGameArray)
        {
            var rpsGame = new RpsGame();

            Assert.That(() => rpsGame.RpsGameWinner(bracketedGameArray), Throws.TypeOf<WrongNumberOfPlayersError>());
        }

        [TestCase("[ [\"Armando\", \"X\"], [\"Dave\", \"S\"] ]")]
        [TestCase("[ [\"Armando\", \"z\"], [\"Dave\", \"y\"] ]")]
        public void Deve_Retornar_Excecao_Caso_Estrategia_Jogo_Diferente_RPS(string bracketedGameArray)
        {
            var rpsGame = new RpsGame();

            Assert.That(() => rpsGame.RpsGameWinner(bracketedGameArray), Throws.TypeOf<NoSuchStrategyError>());
        }        

        [TestCase("[ ['David E.', 'R'], ['Richard X.', 'R'] ]", "[ ['David E.', 'R'] ]", Description = "Deve vencer o primeiro jogador, pois o jogo entre os dois é igual")]
        [TestCase("[ ['JOSE', 'p'], ['JOAO', 'p'] ]", "[ ['JOSE', 'p'] ]", Description = "Deve vencer o primeiro jogador, pois o jogo entre os dois é igual")]
        [TestCase("[ ['Jogador Tesoura', 'S'], ['Jogador Papel', 'P'] ]", "[ ['Jogador Tesoura', 'S'] ]", Description = "Deve vencer o jogador com tesoura")]
        [TestCase("[ ['Jogador Pedra', 'R'], ['Jogador Tesoura', 'S'] ]", "[ ['Jogador Pedra', 'R'] ]", Description = "Deve vencer o jogador com a pedra")]
        [TestCase("[ ['Jogador Papel', 'P'], ['Jogador Pedra', 'R'] ]", "[ ['Jogador Papel', 'P'] ]", Description = "Deve vencer o jogador com o papel")]
        public void Deve_Vencer_Jogador_Conforme_Regras_Estabelecidas_RPS(string bracketedGameArray, string expectedWinner)
        {
            var rpsGame = new RpsGame();

            var expectedWinnerPlayer = new Player(expectedWinner);
            var winnerPlayer = rpsGame.RpsGameWinner<Player>(bracketedGameArray);

            Assert.AreEqual(winnerPlayer.Name, expectedWinnerPlayer.Name);
        }       
    }
}
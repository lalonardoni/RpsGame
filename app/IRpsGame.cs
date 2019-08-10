namespace app
{
    public interface IRpsGame
    {
        T RpsGameWinner<T>(string bracketedGameArray);

        string RpsGameWinner(string bracketedGameArray);
    }
}
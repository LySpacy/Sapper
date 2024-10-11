using Sapper.Game.GameControllers;

class Program
{
    public static void Main()
    {

        int height = 10;  // Высота игрового поля
        int width = 10;   // Ширина игрового поля
        
        Console.WriteLine("Укажите количество бомб");
        int bombCount = int.Parse(Console.ReadLine());  

        var gameController = new GameController();

        gameController.Initial(height, width, bombCount);

        gameController.PlayGame();
    }
}
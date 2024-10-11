namespace Sapper.Game.Controllers.Handlers.ConsoleLogic
{
    public class InputHandler
    {
        public (int row, int col, bool isFlag) ReadPlayerMove(int height, int width)
        {
            while (true)
            {
                string input = Console.ReadLine();

                string[] parts = input.Split(' ');

                if (parts.Length >= 2 && int.TryParse(parts[0], out int row) && int.TryParse(parts[1], out int col))
                {
                    bool isFlag = parts.Length == 3 && parts[2].Trim() == "*";

                    if (row >= 0 && row < height && col >= 0 && col < width)
                    {
                        return (row, col, isFlag);
                    }
                    else
                    {
                        Console.WriteLine("Координаты вне границ поля. Попробуйте снова.");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                }
            }
        }
    }
}

using Sapper.Game.Models.GameField;

namespace Sapper.Game.Controllers.Handlers.ConsoleLogic
{
    public class GameRenderer
    {
        public void PrintField(Field field)
        {
            Console.Clear();
            ShowInputFormat();
            Console.WriteLine("Текущая игровая ситуация:\n");

            Console.Write("    ");
            for (int col = 0; col < field.Width; col++)
            {
                Console.Write($"{col,2}  ");
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', field.Width * 4 + 3));

            for (int row = 0; row < field.Height; row++)
            {
                Console.Write($"{row,2}|");

                for (int col = 0; col < field.Width; col++)
                {
                    var cell = field.GetCell(row, col);
                    Console.ResetColor();

                    if (cell.HasFlag)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" o  ");
                    }
                    else if (!cell.IsOpen)
                    {
                        Console.Write(" *  ");
                    }
                    else if (cell.HasBomb)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" B  ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($" {cell.BombCount}  ");
                    }
                }

                Console.ResetColor();
                Console.WriteLine(" |");
                Console.WriteLine(new string('-', field.Width * 4 + 3));
            }
        }

        public void PrintGameOver()
        {
            Console.WriteLine("Вы попали на бомбу. Игра проиграна!");
        }
        private static void ShowInputFormat()
        {
            Console.WriteLine("Формат ввода:");
            Console.WriteLine("1. Для открытия ячейки: 'row col' (например: '1 2').");
            Console.WriteLine("2. Для установки флажка: 'row col *' (например: '1 2 *').");
            Console.WriteLine("-------------------------------------------------------");
        }

        public void ShowInstructions()
        {
            Console.WriteLine("Инструкция по игре:");
            Console.WriteLine("1. Вводите координаты ячейки, которую хотите открыть, в формате 'row col'.");
            Console.WriteLine("2. Чтобы установить флажок на ячейку, введите координаты с символом '*', например: '1 2 *'.");
            Console.WriteLine("3. Если вы открываете ячейку с бомбой, игра закончится.");
            Console.WriteLine("4. Если вы открываете все ячейки без бомб, вы выиграли!");
            Console.WriteLine("5. Пример ввода: '0 0' для открытия ячейки в первой строке и первом столбце.");
            Console.WriteLine("-------------------------------------------------------");
        }
    }
}

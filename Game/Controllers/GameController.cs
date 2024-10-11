using Sapper.Game.Controllers.Handlers.ConsoleLogic;
using Sapper.Game.Controllers.Handlers.GameLogic;
using Sapper.Game.Models.GameField;

namespace Sapper.Game.GameControllers
{
    public class GameController
    {
        private Field _field;
        private bool _isFirstMove;
        private int _bombCount;

        private readonly InputHandler _inputHandler = new InputHandler();
        private readonly GameRenderer _renderer = new GameRenderer();
        private readonly CellOpener _cellOpener = new CellOpener();

        public void Initial(int height, int width, int bombCount)
        {
            _bombCount = bombCount;
            _isFirstMove = true;
            _field = Field.Create(height, width, 0, -1, -1);
        }

        public void PlayGame()
        {
            _renderer.ShowInstructions();
            Console.WriteLine("Для старта игры нажмите любую кнопку");
            Console.ReadKey();

            while (true)
            {
                _renderer.PrintField(_field);
                (int row, int col, bool isFlag) = _inputHandler.ReadPlayerMove(_field.Height, _field.Width);

                if (_isFirstMove)
                {
                    _field = Field.Create(_field.Height, _field.Width, _bombCount, row, col);
                    _isFirstMove = false;
                }

                if (isFlag)
                {
                    var cell = _field.GetCell(row, col);
                    cell.ToggleFlag();
                }
                else
                {
                    if (_cellOpener.OpenCell(_field, row, col, isFlag))
                    {
                        _renderer.PrintGameOver();
                        Restart();
                        break;
                    }
                }

                _renderer.PrintField(_field);

                if (CheckWinCondition())
                {
                    Console.WriteLine("Поздравляем! Вы выиграли!");
                    Restart();
                    break;
                }
            }
        }

        private bool CheckWinCondition()
        {
            for (int i = 0; i < _field.Height; i++)
            {
                for (int j = 0; j < _field.Width; j++)
                {
                    var cell = _field.GetCell(i, j);

                    if (cell.HasBomb && !cell.HasFlag)
                    {
                        return false;
                    }
                    if (!cell.HasBomb && cell.HasFlag)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void Restart()
        {
            Console.WriteLine("Нажмите 'R', чтобы перезапустить игру.");
            Console.WriteLine("Нажмите 'S', чтобы изменить количество бомб.");

            while (true)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.R)
                {
                    Console.WriteLine("Перезапуск игры...");

                    Initial(_field.Height, _field.Width, _bombCount);
                    PlayGame();

                    break;
                }
                else if (key == ConsoleKey.S)
                {
                    Console.WriteLine("Введите новое количество бомб:");

                    if (int.TryParse(Console.ReadLine(), out int newBombCount) && newBombCount > 0)
                    {
                        Console.Clear();
                        Console.WriteLine($"Новое количество бомб: {newBombCount}. Перезапуск игры...");

                        Initial(_field.Height, _field.Width, newBombCount);
                        PlayGame();
                    }
                    else
                    {
                        Console.WriteLine("Некорректное количество бомб. Попробуйте снова.");
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Неверный ввод. Попробуйте снова.");
                }
            }
        }
    }

}
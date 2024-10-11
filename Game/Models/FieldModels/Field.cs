namespace Sapper.Game.Models.GameField
{
    public class Field
    {
        private readonly Cell[,] _cells;
        private Field(int height, int width)
        {
            ValidateDimensions(height, width);

            Height = height;
            Width = width;
            _cells = new Cell[height, width];
        }

        public int Height { get; }
        public int Width { get; }


        public static Field Create(int height, int width, int bombCount, int safeRow, int safeCol)
        {
            ValidateDimensions(height, width);

            var field = new Field(height, width);
            field.FillCells();

            var bombController = new BombController();

            bombController.PlaceBombs(field, bombCount, safeRow, safeCol);
            bombController.CalculateBombCounts(field);

            return field;
        }

        public Cell GetCell(int row, int col)
        {
            return _cells[row, col];
        }

        private static void ValidateDimensions(int height, int width)
        {
            if (height <= 0)
            {
                throw new ArgumentException("Высота не может быть меньше или равна 0");
            }

            if (width <= 0)
            {
                throw new ArgumentException("Ширина не может быть меньше или равна 0");
            }
        }

        private void FillCells()
        {
            for (int i = 0; i < _cells.GetLength(0); i++)
            {
                for (int j = 0; j < _cells.GetLength(1); j++)
                {
                    _cells[i, j] = new Cell(this, i, j);
                }
            }
        }

    }
}

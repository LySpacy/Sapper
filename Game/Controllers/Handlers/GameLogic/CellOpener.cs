using Sapper.Game.Models.GameField;

namespace Sapper.Game.Controllers.Handlers.GameLogic
{
    public class CellOpener
    {
        public bool OpenCell(Field field, int row, int col, bool isFlag)
        {
            var cell = field.GetCell(row, col);

            if (isFlag)
            {
                if (!cell.IsOpen)
                {
                    cell.ToggleFlag();
                }

                return false;
            }

            if (cell.HasBomb)
            {
                return true;
            }

            cell.Open();
            OpenArea(field, row, col);

            return false;
        }

        private void OpenArea(Field field, int row, int col)
        {
            var currentCell = field.GetCell(row, col);

            if (currentCell.BombCount != 0)
            {
                currentCell.Open();

                return;
            }

            for (int rowOffset = -1; rowOffset <= 1; rowOffset++)
            {
                for (int colOffset = -1; colOffset <= 1; colOffset++)
                {
                    if (Math.Abs(rowOffset) + Math.Abs(colOffset) != 1)
                        continue;

                    int newRow = row + rowOffset;
                    int newCol = col + colOffset;

                    if (newRow >= 0 && newRow < field.Height && newCol >= 0 && newCol < field.Width)
                    {
                        var neighborCell = field.GetCell(newRow, newCol);

                        if (!neighborCell.HasBomb && !neighborCell.IsOpen)
                        {
                            neighborCell.Open();

                            if (neighborCell.BombCount == 0)
                            {
                                OpenArea(field, newRow, newCol);
                            }
                        }
                    }
                }
            }
        }
    }
}

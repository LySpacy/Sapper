using Sapper.Game.Models.GameField;

namespace Sapper.Game.Models
{
    public partial class BombController 
    {
        public class BombCounter
        {
            public void CalculateBombCounts(Field field)
            {
                for (int i = 0; i < field.Height; i++)
                {
                    for (int j = 0; j < field.Width; j++)
                    {
                        var cell = field.GetCell(i, j);
                        if (cell.HasBomb)
                        {
                            UpdateNeighbors(field, i, j);
                        }
                    }
                }
            }

            private void UpdateNeighbors(Field field, int bombRow, int bombCol)
            {
                for (int rowOffset = -1; rowOffset <= 1; rowOffset++)
                {
                    for (int colOffset = -1; colOffset <= 1; colOffset++)
                    {
                        int newRow = bombRow + rowOffset;
                        int newCol = bombCol + colOffset;

                        if (newRow >= 0 && newRow < field.Height && newCol >= 0 && newCol < field.Width)
                        {
                            var neighborCell = field.GetCell(newRow, newCol);
                            if (!neighborCell.HasBomb)
                            {
                                neighborCell.IncrementBombCount();
                            }
                        }
                    }
                }
            }
        }


    }
}

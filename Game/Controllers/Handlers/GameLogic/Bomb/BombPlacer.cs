using Sapper.Game.Models.GameField;

namespace Sapper.Game.Models
{
    public partial class BombController 
    {
        public class BombPlacer
        {
            public void PlaceBombs(Field field, int bombCount, int safeRow, int safeCol)
            {
                var random = new Random();
                int placedBombs = 0;

                while (placedBombs < bombCount)
                {
                    int row = random.Next(0, field.Height);
                    int col = random.Next(0, field.Width);

                    if ((row == safeRow && col == safeCol) || field.GetCell(row, col).HasBomb)
                        continue;

                    field.GetCell(row, col).PlaceBomb();
                    placedBombs++;
                }
            }
        }


    }
}

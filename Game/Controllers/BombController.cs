using Sapper.Game.Models.GameField;

namespace Sapper.Game.Models
{
    public partial class BombController
    {
        private readonly BombPlacer _bombPlacer;
        private readonly BombCounter _bombCounter;

        public BombController()
        {
            _bombPlacer = new BombPlacer();
            _bombCounter = new BombCounter();
        }

        public void PlaceBombs(Field field, int bombCount, int safeRow, int safeCol)
        {
            _bombPlacer.PlaceBombs(field, bombCount, safeRow, safeCol);
        }

        public void CalculateBombCounts(Field field)
        {
            _bombCounter.CalculateBombCounts(field);
        }
    }
}

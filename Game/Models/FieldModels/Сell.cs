
namespace Sapper.Game.Models.GameField
{
    public class Cell
    {
        private readonly Field _field;
        public Cell(Field field, int x, int y)
        {
            _field = field;
            X = x;
            Y = y;
        }
        public int X { get; }
        public int Y { get; }
        public int BombCount { get; private set; } = 0;
        public bool HasBomb { get; private set; }
        public bool IsOpen { get; private set; }
        public bool HasFlag { get; private set; } = false;

        public void PlaceBomb()
        {
            HasBomb = true;
        }

        public void IncrementBombCount()
        {
            BombCount++;
        }

        public void Open()
        {
            IsOpen = true;
        }

        public void ToggleFlag()
        {
            HasFlag = !HasFlag;
        }
    }
}

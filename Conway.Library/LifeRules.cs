namespace Conway.Library
{
    public class LifeRules
    {
        public static CellState GetNewState(CellState currentState, int liveNeighbors)
        {
            switch (currentState)
            {
                case CellState.Alive when liveNeighbors == 3 || liveNeighbors == 2:
                case CellState.Dead when liveNeighbors == 3:
                    return CellState.Alive;
                default:
                    return CellState.Dead;
            }
        }
    }
}
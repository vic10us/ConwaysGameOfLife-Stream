using System;
using System.Collections.Generic;
using System.Linq;

namespace Conway.Library
{
    public class Cell
    {
        public CellState State;
        public CellState Next;
        public readonly List<Cell> Neighbors = new List<Cell>();
        public int LiveNeighbors => Neighbors.Count(x => x.State.Equals(CellState.Alive));
        public CellState NextState => LifeRules.GetNewState(State, LiveNeighbors);
    }
}

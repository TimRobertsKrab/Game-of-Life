using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_Life {
    partial class Grid {

        private Cell[,] cells;

        // public Oscillator[] oscillators;
        public List<Oscillator> oscillators = new List<Oscillator>();
        private int cellLength;

        public Grid(int length,int cellLength) {
            cells = new Cell[length, length];
                     
            for (int x = 0; x < length; x++) {
                for (int y = 0; y < length; y++) {
                    cells[x, y] = new Cell(x, y);
                }
            }
            this.cellLength = cellLength;
            SetOscillators();
        }

        //Sets the cell state to be the one provided.
        public void SetCellState(int x, int y, Cell.State state) {
            cells[x, y].state = state;
        }

        public Cell.State GetCellState(int x, int y) {
            return cells[x, y].state;
        }

        public void SetCellNextState(int x, int y, Cell.State state) {
            cells[x, y].nextState = state;
        }

        //Sets the cell state to be it's next state.
        public void SetCellState(int x, int y) {
            cells[x, y].state = cells[x, y].nextState;
        }

        public void SwitchState(int xCoord, int yCoord, int cellLength) {
            int arrayX = xCoord / cellLength;
            int arrayY = yCoord / cellLength;

            if (arrayX < cells.GetLength(0) && arrayY < cells.GetLength(0)) {

                if (cells[arrayX, arrayY].state == Cell.State.Alive) {
                    cells[arrayX, arrayY].state = Cell.State.Dead;
                }
                else {
                    cells[arrayX, arrayY].state = Cell.State.Alive;
                }
            }
        }

        public void PlaceOscillator(int xCoord, int yCoord, int oscIndex) {
            Oscillator osc = oscillators[oscIndex];

            int arrayX = xCoord / cellLength;
            int arrayY = yCoord / cellLength;

            int xNew, yNew;

            if (arrayX < cells.GetLength(0) && arrayY < cells.GetLength(0)) {
                for (int x = arrayX - osc.GetWidth()/2, i = 0; i<osc.GetWidth(); x++, i++) {
                    xNew = x;
                    if (x < 0) {
                        xNew = cells.GetLength(0) + x;
                    }
                    else if (x > cells.GetLength(0) - 1) {
                        xNew = x - cells.GetLength(0);
                    }
                    for (int y = arrayY - osc.GetHeight()/2, j = 0; j < osc.GetHeight(); y++, j++) {
                        yNew = y;
                        if (y < 0) {
                            yNew = cells.GetLength(1) + y;
                        }
                        else if (y > cells.GetLength(1) - 1) {
                            yNew = y - cells.GetLength(1);
                        }
                        SetCellState(xNew, yNew, osc.GetStateAtCoord(i,j));
                    }
                }
            }
        }

        
    }
}

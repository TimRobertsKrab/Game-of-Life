using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_Life {
    class Game {

        Grid grid;
        int gridLength;
        Main main;

        public Game(Main m,Grid g, int length) {
            grid = g;
            gridLength = length;
            main = m;
        }

        public void Play() {
            int liveCount = 0;
            
            for (int x = 0; x < gridLength; x++) {
                for (int y = 0; y < gridLength; y++) {
                    liveCount = GetLiveNeighbourCount(x, y);
                    if (grid.GetCellState(x, y) == Cell.State.Alive) {
                        if (liveCount < 2 || liveCount > 3) {
                            grid.SetCellNextState(x, y, Cell.State.Dead);
                        }
                        else {
                            grid.SetCellNextState(x, y, Cell.State.Alive);
                        }
                    }
                    else {
                        if (liveCount == 3) {
                            grid.SetCellNextState(x, y, Cell.State.Alive);
                        }
                        else {
                            grid.SetCellNextState(x, y, Cell.State.Dead);
                        }
                    }
                }     
            }
            UpdateStates();
        }

        private int GetLiveNeighbourCount(int x, int y) {
            int count = 0;
            int xCoord, yCoord;
            for (int i = x - 1; i < x + 2; i++) {
                xCoord = i;
                if (i < 0) {
                    xCoord = gridLength - 1;
                }
                else if (i > gridLength - 1) {
                    xCoord = 0;
                }
                for (int j = y - 1; j < y + 2; j++) {
                    if (i == x && j == y) 
                        continue;
                    yCoord = j;
                    if (j < 0) {
                        yCoord = gridLength - 1;
                    }
                    else if (j > gridLength - 1) {
                        yCoord = 0;
                    }
                    if (grid.GetCellState(xCoord,yCoord) == Cell.State.Alive) {
                        count++;
                    }
                }
            }
            
            return count;
        }

        private void UpdateStates() {
            for (int x = 0; x < gridLength; x++) {
                for (int y = 0; y < gridLength; y++) {
                    grid.SetCellState(x, y);
                }
            }
        }

        
    }
}

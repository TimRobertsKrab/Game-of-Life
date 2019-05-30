using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_Life {
    class Cell {

        private int[] Position { get; set; }
        public State state { get; set; }
        public State nextState;

        public enum State {
            Alive = 0, Dead = 1
        }
        

        public Cell(int x, int y) {
            Position = new int[] { x, y};
            state = State.Dead;
            nextState = state;
            
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Game_of_Life {
    partial class Grid {
        public class Oscillator {
            private Cell.State[,] pattern;
            private string name;

            public Oscillator(Cell.State[,] pattern, string name) {
                this.pattern = pattern;
                this.name = name;
            }

            public Cell.State GetStateAtCoord(int x, int y) {
                return pattern[x, y];
            }

            public string GetName() {
                return name;
            }

            public int GetWidth() {
                return pattern.GetLength(0);
            }

            public int GetHeight() {
                return pattern.GetLength(1);
            }
        }

        private void SetOscillators() {
            using (StreamReader reader = new StreamReader("oscillator.init")) {
                if (reader == null) {
                    throw new NullReferenceException();
                }

                reader.ReadLine();
                int d1, d2;
                Cell.State[,] tempPattern;
                string name;

                while (!reader.EndOfStream) {
                    d1 = Int32.Parse(reader.ReadLine());
                    d2 = Int32.Parse(reader.ReadLine());
                    tempPattern = new Cell.State[d1, d2];
                    string line;
                    int x = 0;
                    for (int y = 0; y < d2; y++) {
                        line = reader.ReadLine();
                        x = 0;
                        foreach (char c in line) {
                            tempPattern[x, y] = c == '1' ? Cell.State.Alive : Cell.State.Dead;
                            x++;
                        }
                    }
                    name = reader.ReadLine();
                    oscillators.Add(new Oscillator(tempPattern, name));
                    reader.ReadLine();
                }
            }
        }
    }
}

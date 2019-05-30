using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Game_of_Life {
    public partial class Main : Form { 

        Grid grid;
        PictureBox pb;
        private const int GRID_LENGTH = 100;
        private int cellLength;
        private int initialAliveCells = 0;
        Bitmap array;
        Graphics g;
        private bool paused;

        public Main() {
            InitializeComponent();
            cellLength = pb.Height / GRID_LENGTH;
            grid = new Grid(GRID_LENGTH,cellLength);
            for (int i = 0; i < grid.oscillators.Count; i++) {
                inputTypeBox.Items.Add(grid.oscillators[i].GetName());
            }
            array = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(array);
            paused = true;
            DrawGrid();
            PlayGame();
        }

        async void PlayGame() {
            Game game = new Game(this, grid, GRID_LENGTH);
            while (true) {
                while (paused) {
                    await Task.Delay(50);
                }
                await Task.Delay(100);
                game.Play();
                DrawGrid();
            }
        }

        public void DrawGrid() {
  
            
            for (int x = 0; x < GRID_LENGTH; x++) {
                for (int y = 0; y < GRID_LENGTH; y++) {
                    if (grid.GetCellState(x, y) == Cell.State.Alive){
                        g.FillRectangle(Brushes.Black, x*cellLength, y*cellLength, cellLength, cellLength);
                    }
                    else {
                        g.FillRectangle(Brushes.White, x * cellLength, y * cellLength, cellLength, cellLength);
                    }

                    g.DrawRectangle(Pens.Gray, x*cellLength, y*cellLength, cellLength ,cellLength);
                }           
            }         
            pb.Image = array;          
        }

        private void InitialiseGrid() {
            for (int x = 0; x < GRID_LENGTH; x++) {
                for(int y = 0; y < GRID_LENGTH; y++) {
                    grid.SetCellState(x, y, Cell.State.Dead);
                    grid.SetCellNextState(x, y, Cell.State.Dead);
                }
            }

            int[,] aliveCells = new int[initialAliveCells,2];
            Random rand = new Random();
            for (int i = 0; i < aliveCells.GetLength(0); i++) {
                aliveCells[i,0] = rand.Next(GRID_LENGTH);
                aliveCells[i,1] = rand.Next(GRID_LENGTH);
                grid.SetCellState(aliveCells[i, 0], aliveCells[i, 1], Cell.State.Alive);
            }


        }

        private void playButton_Click(object sender, EventArgs e) {
            paused = !paused;
            if (paused) {
                playButton.Text = "Start";
                initGridButton.Enabled = true;
            }
            else {
                playButton.Text = "Pause";
                initGridButton.Enabled = false;
            }
        }

        private void switchCellState(object sender, MouseEventArgs e) {
            if (paused) {
                if (inputTypeBox.SelectedIndex == 0) {
                    grid.SwitchState(e.X, e.Y, cellLength);
                }
                else {
                    grid.PlaceOscillator(e.X, e.Y, inputTypeBox.SelectedIndex - 1);
                }
                DrawGrid();
            }
        }

        private void initGridButton_Click(object sender, EventArgs e) {
            initialAliveCells = Int32.Parse(aliveCellsBox.Text);
            InitialiseGrid();
            DrawGrid();
        }
    }

}

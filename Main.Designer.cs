using System.Windows.Forms;

namespace Game_of_Life {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pb = new System.Windows.Forms.PictureBox();
            this.playButton = new System.Windows.Forms.Button();
            this.aliveCellsBox = new System.Windows.Forms.TextBox();
            this.initGridButton = new System.Windows.Forms.Button();
            this.inputTypeBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(11, 11);
            this.pb.Margin = new System.Windows.Forms.Padding(2);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(700, 645);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb.TabIndex = 0;
            this.pb.TabStop = false;
            this.pb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.switchCellState);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(625, 12);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 23);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "Start";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // aliveCellsBox
            // 
            this.aliveCellsBox.Location = new System.Drawing.Point(625, 41);
            this.aliveCellsBox.Name = "aliveCellsBox";
            this.aliveCellsBox.Size = new System.Drawing.Size(47, 20);
            this.aliveCellsBox.TabIndex = 2;
            this.aliveCellsBox.Text = "1500";
            // 
            // initGridButton
            // 
            this.initGridButton.Location = new System.Drawing.Point(678, 39);
            this.initGridButton.Name = "initGridButton";
            this.initGridButton.Size = new System.Drawing.Size(75, 23);
            this.initGridButton.TabIndex = 3;
            this.initGridButton.Text = "Initialise grid";
            this.initGridButton.UseVisualStyleBackColor = true;
            this.initGridButton.Click += new System.EventHandler(this.initGridButton_Click);
            // 
            // inputTypeBox
            // 
            this.inputTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputTypeBox.FormattingEnabled = true;
            inputTypeBox.Items.Add("Toggle Cell");
            this.inputTypeBox.Location = new System.Drawing.Point(625, 87);
            this.inputTypeBox.Name = "inputTypeBox";
            this.inputTypeBox.Size = new System.Drawing.Size(121, 21);
            this.inputTypeBox.TabIndex = 5;
            inputTypeBox.SelectedIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(622, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mouse Input:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(812, 645);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputTypeBox);
            this.Controls.Add(this.initGridButton);
            this.Controls.Add(this.aliveCellsBox);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.pb);
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button playButton;
        private TextBox aliveCellsBox;
        private Button initGridButton;
        private ComboBox inputTypeBox;
        private Label label1;
    }
}


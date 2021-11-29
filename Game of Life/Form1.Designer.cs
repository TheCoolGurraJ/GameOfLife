namespace Game_of_Life
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.Board = new System.Windows.Forms.Panel();
            this.Addbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Board
            // 
            this.Board.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Board.AutoSize = true;
            this.Board.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Board.Location = new System.Drawing.Point(12, 75);
            this.Board.Margin = new System.Windows.Forms.Padding(0);
            this.Board.MinimumSize = new System.Drawing.Size(1100, 550);
            this.Board.Name = "Board";
            this.Board.Size = new System.Drawing.Size(1100, 550);
            this.Board.TabIndex = 2;
            this.Board.Paint += new System.Windows.Forms.PaintEventHandler(this.Board_Paint);
            // 
            // Addbtn
            // 
            this.Addbtn.Location = new System.Drawing.Point(111, 12);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(93, 38);
            this.Addbtn.TabIndex = 3;
            this.Addbtn.Text = "Add";
            this.Addbtn.UseVisualStyleBackColor = true;
            this.Addbtn.Click += new System.EventHandler(this.Addbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1436, 673);
            this.Controls.Add(this.Addbtn);
            this.Controls.Add(this.Board);
            this.Controls.Add(this.button1);
            this.MinimumSize = new System.Drawing.Size(1458, 729);
            this.Name = "Form1";
            this.Text = "GameOfLife";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel Board;
        private System.Windows.Forms.Button Addbtn;
    }
}


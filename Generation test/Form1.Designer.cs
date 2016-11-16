namespace Generation_test
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
            this.labelSeed = new System.Windows.Forms.Label();
            this.textBoxSeed = new System.Windows.Forms.TextBox();
            this.labelHP = new System.Windows.Forms.Label();
            this.labelMP = new System.Windows.Forms.Label();
            this.labelAttack = new System.Windows.Forms.Label();
            this.labelDefense = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxHP = new System.Windows.Forms.TextBox();
            this.textBoxAttack = new System.Windows.Forms.TextBox();
            this.textBoxMP = new System.Windows.Forms.TextBox();
            this.textBoxSpeed = new System.Windows.Forms.TextBox();
            this.textBoxDefense = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.labelActualSeed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSeed
            // 
            this.labelSeed.AutoSize = true;
            this.labelSeed.Location = new System.Drawing.Point(13, 16);
            this.labelSeed.Name = "labelSeed";
            this.labelSeed.Size = new System.Drawing.Size(32, 13);
            this.labelSeed.TabIndex = 0;
            this.labelSeed.Text = "Seed";
            // 
            // textBoxSeed
            // 
            this.textBoxSeed.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxSeed.Location = new System.Drawing.Point(51, 13);
            this.textBoxSeed.Name = "textBoxSeed";
            this.textBoxSeed.Size = new System.Drawing.Size(100, 20);
            this.textBoxSeed.TabIndex = 1;
            this.textBoxSeed.TextChanged += new System.EventHandler(this.textBoxSeed_TextChanged);
            // 
            // labelHP
            // 
            this.labelHP.AutoSize = true;
            this.labelHP.Location = new System.Drawing.Point(22, 42);
            this.labelHP.Name = "labelHP";
            this.labelHP.Size = new System.Drawing.Size(22, 13);
            this.labelHP.TabIndex = 7;
            this.labelHP.Text = "HP";
            // 
            // labelMP
            // 
            this.labelMP.AutoSize = true;
            this.labelMP.Location = new System.Drawing.Point(22, 68);
            this.labelMP.Name = "labelMP";
            this.labelMP.Size = new System.Drawing.Size(23, 13);
            this.labelMP.TabIndex = 8;
            this.labelMP.Text = "MP";
            // 
            // labelAttack
            // 
            this.labelAttack.AutoSize = true;
            this.labelAttack.Location = new System.Drawing.Point(12, 94);
            this.labelAttack.Name = "labelAttack";
            this.labelAttack.Size = new System.Drawing.Size(38, 13);
            this.labelAttack.TabIndex = 9;
            this.labelAttack.Text = "Attack";
            // 
            // labelDefense
            // 
            this.labelDefense.AutoSize = true;
            this.labelDefense.Location = new System.Drawing.Point(3, 120);
            this.labelDefense.Name = "labelDefense";
            this.labelDefense.Size = new System.Drawing.Size(47, 13);
            this.labelDefense.TabIndex = 10;
            this.labelDefense.Text = "Defense";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Speed";
            // 
            // textBoxHP
            // 
            this.textBoxHP.BackColor = System.Drawing.Color.White;
            this.textBoxHP.Location = new System.Drawing.Point(51, 39);
            this.textBoxHP.Name = "textBoxHP";
            this.textBoxHP.ReadOnly = true;
            this.textBoxHP.Size = new System.Drawing.Size(100, 20);
            this.textBoxHP.TabIndex = 12;
            // 
            // textBoxAttack
            // 
            this.textBoxAttack.BackColor = System.Drawing.Color.White;
            this.textBoxAttack.Location = new System.Drawing.Point(51, 91);
            this.textBoxAttack.Name = "textBoxAttack";
            this.textBoxAttack.ReadOnly = true;
            this.textBoxAttack.Size = new System.Drawing.Size(100, 20);
            this.textBoxAttack.TabIndex = 14;
            // 
            // textBoxMP
            // 
            this.textBoxMP.BackColor = System.Drawing.Color.White;
            this.textBoxMP.Location = new System.Drawing.Point(51, 65);
            this.textBoxMP.Name = "textBoxMP";
            this.textBoxMP.ReadOnly = true;
            this.textBoxMP.Size = new System.Drawing.Size(100, 20);
            this.textBoxMP.TabIndex = 13;
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.BackColor = System.Drawing.Color.White;
            this.textBoxSpeed.Location = new System.Drawing.Point(51, 143);
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.ReadOnly = true;
            this.textBoxSpeed.Size = new System.Drawing.Size(100, 20);
            this.textBoxSpeed.TabIndex = 16;
            // 
            // textBoxDefense
            // 
            this.textBoxDefense.BackColor = System.Drawing.Color.White;
            this.textBoxDefense.Location = new System.Drawing.Point(51, 117);
            this.textBoxDefense.Name = "textBoxDefense";
            this.textBoxDefense.ReadOnly = true;
            this.textBoxDefense.Size = new System.Drawing.Size(100, 20);
            this.textBoxDefense.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(164, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 500);
            this.panel1.TabIndex = 17;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // buttonRandom
            // 
            this.buttonRandom.Location = new System.Drawing.Point(158, 13);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(75, 23);
            this.buttonRandom.TabIndex = 18;
            this.buttonRandom.Text = "Random";
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // labelActualSeed
            // 
            this.labelActualSeed.AutoSize = true;
            this.labelActualSeed.Location = new System.Drawing.Point(163, 39);
            this.labelActualSeed.Name = "labelActualSeed";
            this.labelActualSeed.Size = new System.Drawing.Size(85, 13);
            this.labelActualSeed.TabIndex = 19;
            this.labelActualSeed.Text = "placeholderseed";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 574);
            this.Controls.Add(this.labelActualSeed);
            this.Controls.Add(this.buttonRandom);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxSpeed);
            this.Controls.Add(this.textBoxDefense);
            this.Controls.Add(this.textBoxAttack);
            this.Controls.Add(this.textBoxMP);
            this.Controls.Add(this.textBoxHP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelDefense);
            this.Controls.Add(this.labelAttack);
            this.Controls.Add(this.labelMP);
            this.Controls.Add(this.labelHP);
            this.Controls.Add(this.textBoxSeed);
            this.Controls.Add(this.labelSeed);
            this.Name = "Form1";
            this.Text = "Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSeed;
        private System.Windows.Forms.TextBox textBoxSeed;
        private System.Windows.Forms.Label labelHP;
        private System.Windows.Forms.Label labelMP;
        private System.Windows.Forms.Label labelAttack;
        private System.Windows.Forms.Label labelDefense;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxHP;
        private System.Windows.Forms.TextBox textBoxAttack;
        private System.Windows.Forms.TextBox textBoxMP;
        private System.Windows.Forms.TextBox textBoxSpeed;
        private System.Windows.Forms.TextBox textBoxDefense;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.Label labelActualSeed;
    }
}


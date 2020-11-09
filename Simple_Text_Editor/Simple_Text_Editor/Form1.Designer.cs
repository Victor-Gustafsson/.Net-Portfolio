namespace Simple_Text_Editor
{
    partial class MyMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyMainForm));
            this.MyTextBox = new System.Windows.Forms.TextBox();
            this.NewButton = new System.Windows.Forms.Button();
            this.OppenButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SaveAsButton = new System.Windows.Forms.Button();
            this.MySplitContainer = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUtan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxOrd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxRader = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MySplitContainer)).BeginInit();
            this.MySplitContainer.Panel1.SuspendLayout();
            this.MySplitContainer.Panel2.SuspendLayout();
            this.MySplitContainer.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MyTextBox
            // 
            this.MyTextBox.AllowDrop = true;
            this.MyTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MyTextBox.Location = new System.Drawing.Point(0, 0);
            this.MyTextBox.Multiline = true;
            this.MyTextBox.Name = "MyTextBox";
            this.MyTextBox.Size = new System.Drawing.Size(552, 354);
            this.MyTextBox.TabIndex = 0;
            this.MyTextBox.TextChanged += new System.EventHandler(this.MyTextBox_TextChanged);
            this.MyTextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.MyTextBox_DragDrop);
            this.MyTextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.MyTextBox_DragEnter);
            // 
            // NewButton
            // 
            this.NewButton.Location = new System.Drawing.Point(3, 3);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(75, 23);
            this.NewButton.TabIndex = 1;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // OppenButton
            // 
            this.OppenButton.Location = new System.Drawing.Point(84, 3);
            this.OppenButton.Name = "OppenButton";
            this.OppenButton.Size = new System.Drawing.Size(75, 23);
            this.OppenButton.TabIndex = 2;
            this.OppenButton.Text = "Open";
            this.OppenButton.UseVisualStyleBackColor = true;
            this.OppenButton.Click += new System.EventHandler(this.OppenButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(165, 3);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SaveAsButton
            // 
            this.SaveAsButton.Location = new System.Drawing.Point(246, 3);
            this.SaveAsButton.Name = "SaveAsButton";
            this.SaveAsButton.Size = new System.Drawing.Size(75, 23);
            this.SaveAsButton.TabIndex = 3;
            this.SaveAsButton.Text = "Save as";
            this.SaveAsButton.UseVisualStyleBackColor = true;
            this.SaveAsButton.Click += new System.EventHandler(this.SaveAsButton_Click);
            // 
            // MySplitContainer
            // 
            this.MySplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MySplitContainer.IsSplitterFixed = true;
            this.MySplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MySplitContainer.Name = "MySplitContainer";
            this.MySplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MySplitContainer.Panel1
            // 
            this.MySplitContainer.Panel1.Controls.Add(this.flowLayoutPanel1);
            this.MySplitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // MySplitContainer.Panel2
            // 
            this.MySplitContainer.Panel2.Controls.Add(this.flowLayoutPanel2);
            this.MySplitContainer.Panel2.Controls.Add(this.MyTextBox);
            this.MySplitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MySplitContainer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MySplitContainer.Size = new System.Drawing.Size(552, 381);
            this.MySplitContainer.SplitterDistance = 26;
            this.MySplitContainer.SplitterWidth = 1;
            this.MySplitContainer.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.NewButton);
            this.flowLayoutPanel1.Controls.Add(this.OppenButton);
            this.flowLayoutPanel1.Controls.Add(this.SaveButton);
            this.flowLayoutPanel1.Controls.Add(this.SaveAsButton);
            this.flowLayoutPanel1.Controls.Add(this.ClearButton);
            this.flowLayoutPanel1.Controls.Add(this.ExitButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(552, 27);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(327, 3);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 4;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(408, 3);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitProgram_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.textBoxMed);
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.textBoxUtan);
            this.flowLayoutPanel2.Controls.Add(this.label3);
            this.flowLayoutPanel2.Controls.Add(this.textBoxOrd);
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.textBoxRader);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 329);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(552, 25);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "With spaces:";
            // 
            // textBoxMed
            // 
            this.textBoxMed.Location = new System.Drawing.Point(78, 3);
            this.textBoxMed.Name = "textBoxMed";
            this.textBoxMed.Size = new System.Drawing.Size(67, 20);
            this.textBoxMed.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(151, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Without spaces:";
            // 
            // textBoxUtan
            // 
            this.textBoxUtan.Location = new System.Drawing.Point(241, 3);
            this.textBoxUtan.Name = "textBoxUtan";
            this.textBoxUtan.Size = new System.Drawing.Size(67, 20);
            this.textBoxUtan.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(314, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Words:";
            // 
            // textBoxOrd
            // 
            this.textBoxOrd.Location = new System.Drawing.Point(361, 3);
            this.textBoxOrd.Name = "textBoxOrd";
            this.textBoxOrd.Size = new System.Drawing.Size(67, 20);
            this.textBoxOrd.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(434, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Lines:";
            // 
            // textBoxRader
            // 
            this.textBoxRader.Location = new System.Drawing.Point(475, 3);
            this.textBoxRader.Name = "textBoxRader";
            this.textBoxRader.Size = new System.Drawing.Size(67, 20);
            this.textBoxRader.TabIndex = 1;
            // 
            // MyMainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 381);
            this.Controls.Add(this.MySplitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(568, 420);
            this.Name = "MyMainForm";
            this.Text = "My simple text editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyMainForm_FormClosing);
            this.MySplitContainer.Panel1.ResumeLayout(false);
            this.MySplitContainer.Panel2.ResumeLayout(false);
            this.MySplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MySplitContainer)).EndInit();
            this.MySplitContainer.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox MyTextBox;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Button OppenButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button SaveAsButton;
        private System.Windows.Forms.SplitContainer MySplitContainer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUtan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxOrd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxRader;
    }
}


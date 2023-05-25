namespace cliesx
{
    partial class cliesx
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cliesx));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.CmdComboBox = new System.Windows.Forms.ComboBox();
            this.cmdDescLabel = new System.Windows.Forms.Label();
            this.execButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CmdComboBox
            // 
            this.CmdComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CmdComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmdComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmdComboBox.FormattingEnabled = true;
            this.CmdComboBox.Location = new System.Drawing.Point(12, 46);
            this.CmdComboBox.Name = "CmdComboBox";
            this.CmdComboBox.Size = new System.Drawing.Size(453, 21);
            this.CmdComboBox.Sorted = true;
            this.CmdComboBox.TabIndex = 1;
            this.CmdComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmdComboBox_KeyDown);
            // 
            // cmdDescLabel
            // 
            this.cmdDescLabel.AutoSize = true;
            this.cmdDescLabel.Location = new System.Drawing.Point(12, 18);
            this.cmdDescLabel.Name = "cmdDescLabel";
            this.cmdDescLabel.Size = new System.Drawing.Size(178, 13);
            this.cmdDescLabel.TabIndex = 2;
            this.cmdDescLabel.Text = "コマンドを入力または選択してください";
            // 
            // execButton
            // 
            this.execButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.execButton.Location = new System.Drawing.Point(471, 46);
            this.execButton.Name = "execButton";
            this.execButton.Size = new System.Drawing.Size(79, 23);
            this.execButton.TabIndex = 3;
            this.execButton.Text = "実行";
            this.execButton.UseVisualStyleBackColor = true;
            this.execButton.Click += new System.EventHandler(this.execButton_Click);
            // 
            // cliesx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 89);
            this.Controls.Add(this.execButton);
            this.Controls.Add(this.cmdDescLabel);
            this.Controls.Add(this.CmdComboBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "cliesx";
            this.Text = "cliesx (0.0.1)";
            this.Load += new System.EventHandler(this.cliesx_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox CmdComboBox;
        private System.Windows.Forms.Label cmdDescLabel;
        private System.Windows.Forms.Button execButton;
    }
}
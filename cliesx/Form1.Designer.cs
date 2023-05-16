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
            this.components = new System.ComponentModel.Container();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.CmdComboBox = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdDescLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CmdComboBox
            // 
            this.CmdComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmdComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmdComboBox.FormattingEnabled = true;
            this.CmdComboBox.Location = new System.Drawing.Point(12, 56);
            this.CmdComboBox.Name = "CmdComboBox";
            this.CmdComboBox.Size = new System.Drawing.Size(323, 21);
            this.CmdComboBox.Sorted = true;
            this.CmdComboBox.TabIndex = 1;
            this.CmdComboBox.SelectedValueChanged += new System.EventHandler(this.CmdComboBox_SelectedValueChanged);
            this.CmdComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmdComboBox_KeyDown);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 0;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 0;
            this.toolTip1.ShowAlways = true;
            // 
            // cmdDescLabel
            // 
            this.cmdDescLabel.AutoSize = true;
            this.cmdDescLabel.Location = new System.Drawing.Point(9, 19);
            this.cmdDescLabel.Name = "cmdDescLabel";
            this.cmdDescLabel.Size = new System.Drawing.Size(126, 13);
            this.cmdDescLabel.TabIndex = 2;
            this.cmdDescLabel.Text = "コマンドを選択してください";
            // 
            // cliesx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 455);
            this.Controls.Add(this.cmdDescLabel);
            this.Controls.Add(this.CmdComboBox);
            this.Name = "cliesx";
            this.Text = "cliesx (0.0.1)";
            this.Load += new System.EventHandler(this.cliesx_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox CmdComboBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label cmdDescLabel;
    }
}
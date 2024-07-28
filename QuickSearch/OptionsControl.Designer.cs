namespace QuickSearch
{
    partial class OptionsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelWidth = new System.Windows.Forms.Label();
            this.ControlWidth = new System.Windows.Forms.NumericUpDown();
            this.backgroundColorGroupBox = new System.Windows.Forms.GroupBox();
            this.MainOptionsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelBGColorSuccess = new System.Windows.Forms.Label();
            this.labelSearchPending = new System.Windows.Forms.Label();
            this.labelBGColorError = new System.Windows.Forms.Label();
            this.labelBGColorNormalUnFocused = new System.Windows.Forms.Label();
            this.labelBGColorFocused = new System.Windows.Forms.Label();
            this.colorSelectButtonSuccess = new QuickSearch.ColorSelectButton();
            this.colorSelectButtonPending = new QuickSearch.ColorSelectButton();
            this.colorSelectButtonError = new QuickSearch.ColorSelectButton();
            this.colorSelectButtonUnfocused = new QuickSearch.ColorSelectButton();
            this.colorSelectButtonFocused = new QuickSearch.ColorSelectButton();
            ((System.ComponentModel.ISupportInitialize)(this.ControlWidth)).BeginInit();
            this.backgroundColorGroupBox.SuspendLayout();
            this.MainOptionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelWidth
            // 
            this.labelWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(5, 290);
            this.labelWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(111, 16);
            this.labelWidth.TabIndex = 11;
            this.labelWidth.Text = "Search box width:";
            this.labelWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ControlWidth
            // 
            this.ControlWidth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ControlWidth.AutoSize = true;
            this.ControlWidth.Location = new System.Drawing.Point(154, 287);
            this.ControlWidth.Margin = new System.Windows.Forms.Padding(4);
            this.ControlWidth.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ControlWidth.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.ControlWidth.Name = "ControlWidth";
            this.ControlWidth.Size = new System.Drawing.Size(55, 22);
            this.ControlWidth.TabIndex = 0;
            this.ControlWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ControlWidth.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // backgroundColorGroupBox
            // 
            this.backgroundColorGroupBox.Controls.Add(this.MainOptionsPanel);
            this.backgroundColorGroupBox.Location = new System.Drawing.Point(8, 15);
            this.backgroundColorGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.backgroundColorGroupBox.Name = "backgroundColorGroupBox";
            this.backgroundColorGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.backgroundColorGroupBox.Size = new System.Drawing.Size(720, 252);
            this.backgroundColorGroupBox.TabIndex = 1;
            this.backgroundColorGroupBox.TabStop = false;
            this.backgroundColorGroupBox.Text = "Background color";
            // 
            // MainOptionsPanel
            // 
            this.MainOptionsPanel.AutoSize = true;
            this.MainOptionsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainOptionsPanel.ColumnCount = 3;
            this.MainOptionsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainOptionsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainOptionsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 509F));
            this.MainOptionsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainOptionsPanel.Controls.Add(this.labelBGColorSuccess, 0, 2);
            this.MainOptionsPanel.Controls.Add(this.colorSelectButtonSuccess, 1, 2);
            this.MainOptionsPanel.Controls.Add(this.labelSearchPending, 0, 3);
            this.MainOptionsPanel.Controls.Add(this.colorSelectButtonPending, 1, 3);
            this.MainOptionsPanel.Controls.Add(this.labelBGColorError, 0, 4);
            this.MainOptionsPanel.Controls.Add(this.colorSelectButtonError, 1, 4);
            this.MainOptionsPanel.Controls.Add(this.labelBGColorNormalUnFocused, 0, 5);
            this.MainOptionsPanel.Controls.Add(this.colorSelectButtonUnfocused, 1, 5);
            this.MainOptionsPanel.Controls.Add(this.labelBGColorFocused, 0, 6);
            this.MainOptionsPanel.Controls.Add(this.colorSelectButtonFocused, 1, 6);
            this.MainOptionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainOptionsPanel.Location = new System.Drawing.Point(4, 19);
            this.MainOptionsPanel.Margin = new System.Windows.Forms.Padding(4, 15, 4, 4);
            this.MainOptionsPanel.Name = "MainOptionsPanel";
            this.MainOptionsPanel.RowCount = 12;
            this.MainOptionsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainOptionsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainOptionsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainOptionsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainOptionsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainOptionsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainOptionsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainOptionsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainOptionsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainOptionsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainOptionsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainOptionsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainOptionsPanel.Size = new System.Drawing.Size(712, 229);
            this.MainOptionsPanel.TabIndex = 1;
            // 
            // labelBGColorSuccess
            // 
            this.labelBGColorSuccess.AutoSize = true;
            this.labelBGColorSuccess.BackColor = System.Drawing.Color.Transparent;
            this.labelBGColorSuccess.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelBGColorSuccess.Location = new System.Drawing.Point(4, 0);
            this.labelBGColorSuccess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBGColorSuccess.Name = "labelBGColorSuccess";
            this.labelBGColorSuccess.Size = new System.Drawing.Size(119, 46);
            this.labelBGColorSuccess.TabIndex = 1;
            this.labelBGColorSuccess.Text = "Search successful:";
            this.labelBGColorSuccess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSearchPending
            // 
            this.labelSearchPending.AutoSize = true;
            this.labelSearchPending.BackColor = System.Drawing.Color.Transparent;
            this.labelSearchPending.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelSearchPending.Location = new System.Drawing.Point(4, 46);
            this.labelSearchPending.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSearchPending.Name = "labelSearchPending";
            this.labelSearchPending.Size = new System.Drawing.Size(123, 46);
            this.labelSearchPending.TabIndex = 16;
            this.labelSearchPending.Text = "Search in progress:";
            this.labelSearchPending.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBGColorError
            // 
            this.labelBGColorError.AutoSize = true;
            this.labelBGColorError.BackColor = System.Drawing.Color.Transparent;
            this.labelBGColorError.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelBGColorError.Location = new System.Drawing.Point(4, 92);
            this.labelBGColorError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBGColorError.Name = "labelBGColorError";
            this.labelBGColorError.Size = new System.Drawing.Size(133, 46);
            this.labelBGColorError.TabIndex = 2;
            this.labelBGColorError.Text = "Search unsuccessful:";
            this.labelBGColorError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBGColorNormalUnFocused
            // 
            this.labelBGColorNormalUnFocused.AutoSize = true;
            this.labelBGColorNormalUnFocused.BackColor = System.Drawing.Color.Transparent;
            this.labelBGColorNormalUnFocused.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelBGColorNormalUnFocused.Location = new System.Drawing.Point(4, 138);
            this.labelBGColorNormalUnFocused.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBGColorNormalUnFocused.Name = "labelBGColorNormalUnFocused";
            this.labelBGColorNormalUnFocused.Size = new System.Drawing.Size(119, 46);
            this.labelBGColorNormalUnFocused.TabIndex = 3;
            this.labelBGColorNormalUnFocused.Text = "Normal unfocused:";
            this.labelBGColorNormalUnFocused.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelBGColorFocused
            // 
            this.labelBGColorFocused.AutoSize = true;
            this.labelBGColorFocused.BackColor = System.Drawing.Color.Transparent;
            this.labelBGColorFocused.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelBGColorFocused.Location = new System.Drawing.Point(4, 184);
            this.labelBGColorFocused.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBGColorFocused.Name = "labelBGColorFocused";
            this.labelBGColorFocused.Size = new System.Drawing.Size(105, 46);
            this.labelBGColorFocused.TabIndex = 4;
            this.labelBGColorFocused.Text = "Normal focused:";
            this.labelBGColorFocused.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // colorSelectButtonSuccess
            // 
            this.colorSelectButtonSuccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.colorSelectButtonSuccess.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.colorSelectButtonSuccess.BackColor = System.Drawing.SystemColors.Control;
            this.colorSelectButtonSuccess.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorSelectButtonSuccess.Color = System.Drawing.SystemColors.Control;
            this.colorSelectButtonSuccess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorSelectButtonSuccess.Location = new System.Drawing.Point(146, 5);
            this.colorSelectButtonSuccess.Margin = new System.Windows.Forms.Padding(5);
            this.colorSelectButtonSuccess.Name = "colorSelectButtonSuccess";
            this.colorSelectButtonSuccess.Size = new System.Drawing.Size(52, 36);
            this.colorSelectButtonSuccess.TabIndex = 1;
            // 
            // colorSelectButtonPending
            // 
            this.colorSelectButtonPending.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.colorSelectButtonPending.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.colorSelectButtonPending.BackColor = System.Drawing.SystemColors.Control;
            this.colorSelectButtonPending.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorSelectButtonPending.Color = System.Drawing.SystemColors.Control;
            this.colorSelectButtonPending.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorSelectButtonPending.Location = new System.Drawing.Point(146, 51);
            this.colorSelectButtonPending.Margin = new System.Windows.Forms.Padding(5);
            this.colorSelectButtonPending.Name = "colorSelectButtonPending";
            this.colorSelectButtonPending.Size = new System.Drawing.Size(52, 36);
            this.colorSelectButtonPending.TabIndex = 2;
            // 
            // colorSelectButtonError
            // 
            this.colorSelectButtonError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.colorSelectButtonError.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.colorSelectButtonError.BackColor = System.Drawing.SystemColors.Control;
            this.colorSelectButtonError.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorSelectButtonError.Color = System.Drawing.SystemColors.Control;
            this.colorSelectButtonError.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorSelectButtonError.Location = new System.Drawing.Point(146, 97);
            this.colorSelectButtonError.Margin = new System.Windows.Forms.Padding(5);
            this.colorSelectButtonError.Name = "colorSelectButtonError";
            this.colorSelectButtonError.Size = new System.Drawing.Size(52, 36);
            this.colorSelectButtonError.TabIndex = 3;
            // 
            // colorSelectButtonUnfocused
            // 
            this.colorSelectButtonUnfocused.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.colorSelectButtonUnfocused.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.colorSelectButtonUnfocused.BackColor = System.Drawing.SystemColors.Control;
            this.colorSelectButtonUnfocused.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorSelectButtonUnfocused.Color = System.Drawing.SystemColors.Control;
            this.colorSelectButtonUnfocused.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorSelectButtonUnfocused.Location = new System.Drawing.Point(146, 143);
            this.colorSelectButtonUnfocused.Margin = new System.Windows.Forms.Padding(5);
            this.colorSelectButtonUnfocused.Name = "colorSelectButtonUnfocused";
            this.colorSelectButtonUnfocused.Size = new System.Drawing.Size(52, 36);
            this.colorSelectButtonUnfocused.TabIndex = 4;
            // 
            // colorSelectButtonFocused
            // 
            this.colorSelectButtonFocused.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.colorSelectButtonFocused.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.colorSelectButtonFocused.BackColor = System.Drawing.SystemColors.Control;
            this.colorSelectButtonFocused.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorSelectButtonFocused.Color = System.Drawing.SystemColors.Control;
            this.colorSelectButtonFocused.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorSelectButtonFocused.Location = new System.Drawing.Point(146, 189);
            this.colorSelectButtonFocused.Margin = new System.Windows.Forms.Padding(5);
            this.colorSelectButtonFocused.Name = "colorSelectButtonFocused";
            this.colorSelectButtonFocused.Size = new System.Drawing.Size(52, 36);
            this.colorSelectButtonFocused.TabIndex = 5;
            // 
            // OptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.ControlWidth);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.backgroundColorGroupBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OptionsControl";
            this.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.Size = new System.Drawing.Size(732, 328);
            ((System.ComponentModel.ISupportInitialize)(this.ControlWidth)).EndInit();
            this.backgroundColorGroupBox.ResumeLayout(false);
            this.backgroundColorGroupBox.PerformLayout();
            this.MainOptionsPanel.ResumeLayout(false);
            this.MainOptionsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown ControlWidth;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.GroupBox backgroundColorGroupBox;
        private System.Windows.Forms.TableLayoutPanel MainOptionsPanel;
        private System.Windows.Forms.Label labelBGColorSuccess;
        private ColorSelectButton colorSelectButtonSuccess;
        private System.Windows.Forms.Label labelSearchPending;
        private ColorSelectButton colorSelectButtonPending;
        private System.Windows.Forms.Label labelBGColorError;
        private ColorSelectButton colorSelectButtonError;
        private System.Windows.Forms.Label labelBGColorNormalUnFocused;
        private ColorSelectButton colorSelectButtonUnfocused;
        private System.Windows.Forms.Label labelBGColorFocused;
        private ColorSelectButton colorSelectButtonFocused;
    }
}

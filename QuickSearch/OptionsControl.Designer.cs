using KeePass.UI;

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
			this.labelBGColorSuccess = new System.Windows.Forms.Label();
			this.colorSelectButtonSuccess = new KeePass.UI.ColorButtonEx();
			this.labelSearchPending = new System.Windows.Forms.Label();
			this.colorSelectButtonPending = new KeePass.UI.ColorButtonEx();
			this.labelBGColorError = new System.Windows.Forms.Label();
			this.colorSelectButtonError = new KeePass.UI.ColorButtonEx();
			this.labelBGColorNormalUnFocused = new System.Windows.Forms.Label();
			this.colorSelectButtonUnfocused = new KeePass.UI.ColorButtonEx();
			this.labelBGColorFocused = new System.Windows.Forms.Label();
			this.colorSelectButtonFocused = new KeePass.UI.ColorButtonEx();
			((System.ComponentModel.ISupportInitialize)(this.ControlWidth)).BeginInit();
			this.backgroundColorGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// labelWidth
			// 
			this.labelWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.labelWidth.AutoSize = true;
			this.labelWidth.Location = new System.Drawing.Point(4, 192);
			this.labelWidth.Name = "labelWidth";
			this.labelWidth.Size = new System.Drawing.Size(92, 13);
			this.labelWidth.TabIndex = 0;
			this.labelWidth.Text = "Search box width:";
			this.labelWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ControlWidth
			// 
			this.ControlWidth.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.ControlWidth.AutoSize = true;
			this.ControlWidth.Location = new System.Drawing.Point(131, 187);
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
			this.ControlWidth.Size = new System.Drawing.Size(47, 20);
			this.ControlWidth.TabIndex = 6;
			this.ControlWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.ControlWidth.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
			// 
			// backgroundColorGroupBox
			// 
			this.backgroundColorGroupBox.Controls.Add(this.labelBGColorSuccess);
			this.backgroundColorGroupBox.Controls.Add(this.colorSelectButtonSuccess);
			this.backgroundColorGroupBox.Controls.Add(this.labelSearchPending);
			this.backgroundColorGroupBox.Controls.Add(this.colorSelectButtonPending);
			this.backgroundColorGroupBox.Controls.Add(this.labelBGColorError);
			this.backgroundColorGroupBox.Controls.Add(this.colorSelectButtonError);
			this.backgroundColorGroupBox.Controls.Add(this.labelBGColorNormalUnFocused);
			this.backgroundColorGroupBox.Controls.Add(this.colorSelectButtonUnfocused);
			this.backgroundColorGroupBox.Controls.Add(this.labelBGColorFocused);
			this.backgroundColorGroupBox.Controls.Add(this.colorSelectButtonFocused);
			this.backgroundColorGroupBox.Location = new System.Drawing.Point(6, 12);
			this.backgroundColorGroupBox.Name = "backgroundColorGroupBox";
			this.backgroundColorGroupBox.Size = new System.Drawing.Size(540, 165);
			this.backgroundColorGroupBox.TabIndex = 0;
			this.backgroundColorGroupBox.TabStop = false;
			this.backgroundColorGroupBox.Text = "Background color";
			// 
			// labelBGColorSuccess
			// 
			this.labelBGColorSuccess.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelBGColorSuccess.AutoSize = true;
			this.labelBGColorSuccess.BackColor = System.Drawing.Color.Transparent;
			this.labelBGColorSuccess.Location = new System.Drawing.Point(5, 21);
			this.labelBGColorSuccess.Name = "labelBGColorSuccess";
			this.labelBGColorSuccess.Size = new System.Drawing.Size(97, 13);
			this.labelBGColorSuccess.TabIndex = 16;
			this.labelBGColorSuccess.Text = "Search successful:";
			// 
			// colorSelectButtonSuccess
			// 
			this.colorSelectButtonSuccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.colorSelectButtonSuccess.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.colorSelectButtonSuccess.Location = new System.Drawing.Point(121, 18);
			this.colorSelectButtonSuccess.Name = "colorSelectButtonSuccess";
			this.colorSelectButtonSuccess.Size = new System.Drawing.Size(37, 22);
			this.colorSelectButtonSuccess.TabIndex = 21;
			this.colorSelectButtonSuccess.UseVisualStyleBackColor = true;
			// 
			// labelSearchPending
			// 
			this.labelSearchPending.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelSearchPending.AutoSize = true;
			this.labelSearchPending.BackColor = System.Drawing.Color.Transparent;
			this.labelSearchPending.Location = new System.Drawing.Point(5, 49);
			this.labelSearchPending.Name = "labelSearchPending";
			this.labelSearchPending.Size = new System.Drawing.Size(98, 13);
			this.labelSearchPending.TabIndex = 17;
			this.labelSearchPending.Text = "Search in progress:";
			// 
			// colorSelectButtonPending
			// 
			this.colorSelectButtonPending.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.colorSelectButtonPending.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.colorSelectButtonPending.Location = new System.Drawing.Point(121, 46);
			this.colorSelectButtonPending.Name = "colorSelectButtonPending";
			this.colorSelectButtonPending.Size = new System.Drawing.Size(37, 22);
			this.colorSelectButtonPending.TabIndex = 22;
			// 
			// labelBGColorError
			// 
			this.labelBGColorError.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelBGColorError.AutoSize = true;
			this.labelBGColorError.BackColor = System.Drawing.Color.Transparent;
			this.labelBGColorError.Location = new System.Drawing.Point(5, 77);
			this.labelBGColorError.Name = "labelBGColorError";
			this.labelBGColorError.Size = new System.Drawing.Size(109, 13);
			this.labelBGColorError.TabIndex = 18;
			this.labelBGColorError.Text = "Search unsuccessful:";
			// 
			// colorSelectButtonError
			// 
			this.colorSelectButtonError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.colorSelectButtonError.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.colorSelectButtonError.Location = new System.Drawing.Point(121, 74);
			this.colorSelectButtonError.Name = "colorSelectButtonError";
			this.colorSelectButtonError.Size = new System.Drawing.Size(37, 22);
			this.colorSelectButtonError.TabIndex = 23;
			// 
			// labelBGColorNormalUnFocused
			// 
			this.labelBGColorNormalUnFocused.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelBGColorNormalUnFocused.AutoSize = true;
			this.labelBGColorNormalUnFocused.BackColor = System.Drawing.Color.Transparent;
			this.labelBGColorNormalUnFocused.Location = new System.Drawing.Point(5, 105);
			this.labelBGColorNormalUnFocused.Name = "labelBGColorNormalUnFocused";
			this.labelBGColorNormalUnFocused.Size = new System.Drawing.Size(96, 13);
			this.labelBGColorNormalUnFocused.TabIndex = 19;
			this.labelBGColorNormalUnFocused.Text = "Normal unfocused:";
			// 
			// colorSelectButtonUnfocused
			// 
			this.colorSelectButtonUnfocused.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.colorSelectButtonUnfocused.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.colorSelectButtonUnfocused.Location = new System.Drawing.Point(121, 102);
			this.colorSelectButtonUnfocused.Name = "colorSelectButtonUnfocused";
			this.colorSelectButtonUnfocused.Size = new System.Drawing.Size(37, 22);
			this.colorSelectButtonUnfocused.TabIndex = 24;
			// 
			// labelBGColorFocused
			// 
			this.labelBGColorFocused.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelBGColorFocused.AutoSize = true;
			this.labelBGColorFocused.BackColor = System.Drawing.Color.Transparent;
			this.labelBGColorFocused.Location = new System.Drawing.Point(5, 133);
			this.labelBGColorFocused.Name = "labelBGColorFocused";
			this.labelBGColorFocused.Size = new System.Drawing.Size(84, 13);
			this.labelBGColorFocused.TabIndex = 20;
			this.labelBGColorFocused.Text = "Normal focused:";
			// 
			// colorSelectButtonFocused
			// 
			this.colorSelectButtonFocused.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.colorSelectButtonFocused.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.colorSelectButtonFocused.Location = new System.Drawing.Point(121, 130);
			this.colorSelectButtonFocused.Name = "colorSelectButtonFocused";
			this.colorSelectButtonFocused.Size = new System.Drawing.Size(37, 22);
			this.colorSelectButtonFocused.TabIndex = 25;
			// 
			// OptionsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.ControlWidth);
			this.Controls.Add(this.labelWidth);
			this.Controls.Add(this.backgroundColorGroupBox);
			this.Name = "OptionsControl";
			this.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
			this.Size = new System.Drawing.Size(549, 222);
			((System.ComponentModel.ISupportInitialize)(this.ControlWidth)).EndInit();
			this.backgroundColorGroupBox.ResumeLayout(false);
			this.backgroundColorGroupBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown ControlWidth;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.GroupBox backgroundColorGroupBox;
		private System.Windows.Forms.Label labelBGColorSuccess;
		private ColorButtonEx colorSelectButtonSuccess;
		private System.Windows.Forms.Label labelSearchPending;
		private ColorButtonEx colorSelectButtonPending;
		private System.Windows.Forms.Label labelBGColorError;
		private ColorButtonEx colorSelectButtonError;
		private System.Windows.Forms.Label labelBGColorNormalUnFocused;
		private ColorButtonEx colorSelectButtonUnfocused;
		private System.Windows.Forms.Label labelBGColorFocused;
		private ColorButtonEx colorSelectButtonFocused;
	}
}

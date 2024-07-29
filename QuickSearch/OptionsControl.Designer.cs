﻿using KeePass.UI;

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
            this.labelSearchPending = new System.Windows.Forms.Label();
            this.labelBGColorError = new System.Windows.Forms.Label();
            this.labelBGColorNormalUnFocused = new System.Windows.Forms.Label();
            this.labelBGColorFocused = new System.Windows.Forms.Label();
            this.colorSelectButtonSuccess = new KeePass.UI.ColorButtonEx();
            this.colorSelectButtonPending = new KeePass.UI.ColorButtonEx();
            this.colorSelectButtonError = new KeePass.UI.ColorButtonEx();
            this.colorSelectButtonUnfocused = new KeePass.UI.ColorButtonEx();
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
            this.labelWidth.Location = new System.Drawing.Point(5, 238);
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
            this.ControlWidth.Location = new System.Drawing.Point(154, 235);
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
            this.backgroundColorGroupBox.Location = new System.Drawing.Point(8, 15);
            this.backgroundColorGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.backgroundColorGroupBox.Name = "backgroundColorGroupBox";
            this.backgroundColorGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.backgroundColorGroupBox.Size = new System.Drawing.Size(720, 206);
            this.backgroundColorGroupBox.TabIndex = 1;
            this.backgroundColorGroupBox.TabStop = false;
            this.backgroundColorGroupBox.Text = "Background color";
            // 
            // labelBGColorSuccess
            // 
            this.labelBGColorSuccess.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelBGColorSuccess.BackColor = System.Drawing.Color.Transparent;
            this.labelBGColorSuccess.Location = new System.Drawing.Point(9, 25);
            this.labelBGColorSuccess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBGColorSuccess.Name = "labelBGColorSuccess";
            this.labelBGColorSuccess.Size = new System.Drawing.Size(119, 16);
            this.labelBGColorSuccess.TabIndex = 17;
            this.labelBGColorSuccess.Text = "Search successful:";
            // 
            // labelSearchPending
            // 
            this.labelSearchPending.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelSearchPending.BackColor = System.Drawing.Color.Transparent;
            this.labelSearchPending.Location = new System.Drawing.Point(9, 60);
            this.labelSearchPending.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSearchPending.Name = "labelSearchPending";
            this.labelSearchPending.Size = new System.Drawing.Size(123, 16);
            this.labelSearchPending.TabIndex = 26;
            this.labelSearchPending.Text = "Search in progress:";
            // 
            // labelBGColorError
            // 
            this.labelBGColorError.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelBGColorError.BackColor = System.Drawing.Color.Transparent;
            this.labelBGColorError.Location = new System.Drawing.Point(9, 95);
            this.labelBGColorError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBGColorError.Name = "labelBGColorError";
            this.labelBGColorError.Size = new System.Drawing.Size(133, 16);
            this.labelBGColorError.TabIndex = 20;
            this.labelBGColorError.Text = "Search unsuccessful:";
            // 
            // labelBGColorNormalUnFocused
            // 
            this.labelBGColorNormalUnFocused.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelBGColorNormalUnFocused.BackColor = System.Drawing.Color.Transparent;
            this.labelBGColorNormalUnFocused.Location = new System.Drawing.Point(9, 130);
            this.labelBGColorNormalUnFocused.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBGColorNormalUnFocused.Name = "labelBGColorNormalUnFocused";
            this.labelBGColorNormalUnFocused.Size = new System.Drawing.Size(119, 16);
            this.labelBGColorNormalUnFocused.TabIndex = 22;
            this.labelBGColorNormalUnFocused.Text = "Normal unfocused:";
            // 
            // labelBGColorFocused
            // 
            this.labelBGColorFocused.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelBGColorFocused.BackColor = System.Drawing.Color.Transparent;
            this.labelBGColorFocused.Location = new System.Drawing.Point(9, 165);
            this.labelBGColorFocused.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBGColorFocused.Name = "labelBGColorFocused";
            this.labelBGColorFocused.Size = new System.Drawing.Size(105, 16);
            this.labelBGColorFocused.TabIndex = 24;
            this.labelBGColorFocused.Text = "Normal focused:";
            // 
            // colorSelectButtonSuccess
            // 
            this.colorSelectButtonSuccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.colorSelectButtonSuccess.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.colorSelectButtonSuccess.Location = new System.Drawing.Point(150, 20);
            this.colorSelectButtonSuccess.Margin = new System.Windows.Forms.Padding(4);
            this.colorSelectButtonSuccess.Name = "colorSelectButtonSuccess";
            this.colorSelectButtonSuccess.Size = new System.Drawing.Size(49, 28);
            this.colorSelectButtonSuccess.TabIndex = 18;
            this.colorSelectButtonSuccess.UseVisualStyleBackColor = true;
            // 
            // colorSelectButtonPending
            // 
            this.colorSelectButtonPending.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.colorSelectButtonPending.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.colorSelectButtonPending.Location = new System.Drawing.Point(150, 55);
            this.colorSelectButtonPending.Margin = new System.Windows.Forms.Padding(4);
            this.colorSelectButtonPending.Name = "colorSelectButtonPending";
            this.colorSelectButtonPending.Size = new System.Drawing.Size(49, 28);
            this.colorSelectButtonPending.TabIndex = 19;
            // 
            // colorSelectButtonError
            // 
            this.colorSelectButtonError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.colorSelectButtonError.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.colorSelectButtonError.Location = new System.Drawing.Point(150, 90);
            this.colorSelectButtonError.Margin = new System.Windows.Forms.Padding(4);
            this.colorSelectButtonError.Name = "colorSelectButtonError";
            this.colorSelectButtonError.Size = new System.Drawing.Size(49, 28);
            this.colorSelectButtonError.TabIndex = 21;
            // 
            // colorSelectButtonUnfocused
            // 
            this.colorSelectButtonUnfocused.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.colorSelectButtonUnfocused.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.colorSelectButtonUnfocused.Location = new System.Drawing.Point(150, 125);
            this.colorSelectButtonUnfocused.Margin = new System.Windows.Forms.Padding(4);
            this.colorSelectButtonUnfocused.Name = "colorSelectButtonUnfocused";
            this.colorSelectButtonUnfocused.Size = new System.Drawing.Size(49, 28);
            this.colorSelectButtonUnfocused.TabIndex = 23;
            // 
            // colorSelectButtonFocused
            // 
            this.colorSelectButtonFocused.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.colorSelectButtonFocused.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.colorSelectButtonFocused.Location = new System.Drawing.Point(150, 160);
            this.colorSelectButtonFocused.Margin = new System.Windows.Forms.Padding(4);
            this.colorSelectButtonFocused.Name = "colorSelectButtonFocused";
            this.colorSelectButtonFocused.Size = new System.Drawing.Size(49, 28);
            this.colorSelectButtonFocused.TabIndex = 25;
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
            this.Size = new System.Drawing.Size(732, 276);
            ((System.ComponentModel.ISupportInitialize)(this.ControlWidth)).EndInit();
            this.backgroundColorGroupBox.ResumeLayout(false);
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

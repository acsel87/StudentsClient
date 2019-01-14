namespace Student_UI
{
    partial class ConfirmReset
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
            this.newPassLabel = new System.Windows.Forms.Label();
            this.confirmPassLabel = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.newPasswordTextBox = new System.Windows.Forms.TextBox();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.passwordResetLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // newPassLabel
            // 
            this.newPassLabel.AutoSize = true;
            this.newPassLabel.Location = new System.Drawing.Point(27, 24);
            this.newPassLabel.Name = "newPassLabel";
            this.newPassLabel.Size = new System.Drawing.Size(110, 21);
            this.newPassLabel.TabIndex = 0;
            this.newPassLabel.Text = "New Password:";
            // 
            // confirmPassLabel
            // 
            this.confirmPassLabel.AutoSize = true;
            this.confirmPassLabel.Location = new System.Drawing.Point(27, 70);
            this.confirmPassLabel.Name = "confirmPassLabel";
            this.confirmPassLabel.Size = new System.Drawing.Size(133, 21);
            this.confirmPassLabel.TabIndex = 1;
            this.confirmPassLabel.Text = "Confirm Password:";
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(182, 116);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(120, 30);
            this.resetButton.TabIndex = 2;
            this.resetButton.Text = "Reset Password";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // newPasswordTextBox
            // 
            this.newPasswordTextBox.Location = new System.Drawing.Point(172, 21);
            this.newPasswordTextBox.Name = "newPasswordTextBox";
            this.newPasswordTextBox.Size = new System.Drawing.Size(300, 29);
            this.newPasswordTextBox.TabIndex = 3;
            this.newPasswordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Password_PreviewInput);
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(172, 70);
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(300, 29);
            this.confirmPasswordTextBox.TabIndex = 4;
            // 
            // passwordResetLabel
            // 
            this.passwordResetLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.passwordResetLabel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.passwordResetLabel.Location = new System.Drawing.Point(156, 116);
            this.passwordResetLabel.Name = "passwordResetLabel";
            this.passwordResetLabel.Size = new System.Drawing.Size(173, 21);
            this.passwordResetLabel.TabIndex = 5;
            this.passwordResetLabel.Text = "Password has been reset";
            this.passwordResetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.passwordResetLabel.Visible = false;
            // 
            // ConfirmReset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(484, 161);
            this.Controls.Add(this.passwordResetLabel);
            this.Controls.Add(this.confirmPasswordTextBox);
            this.Controls.Add(this.newPasswordTextBox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.confirmPassLabel);
            this.Controls.Add(this.newPassLabel);
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 200);
            this.MinimumSize = new System.Drawing.Size(500, 100);
            this.Name = "ConfirmReset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirm Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label newPassLabel;
        private System.Windows.Forms.Label confirmPassLabel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.TextBox newPasswordTextBox;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.Label passwordResetLabel;
    }
}
namespace NotificationDecoratorApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Form variables
        private System.Windows.Forms.CheckBox cbEmail;
        private System.Windows.Forms.CheckBox cbSMS;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button sendButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cbEmail = new System.Windows.Forms.CheckBox();
            this.cbSMS = new System.Windows.Forms.CheckBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbEmail
            // 
            this.cbEmail.AutoSize = true;
            this.cbEmail.Location = new System.Drawing.Point(12, 12);
            this.cbEmail.Name = "cbEmail";
            this.cbEmail.Size = new System.Drawing.Size(87, 17);
            this.cbEmail.TabIndex = 0;
            this.cbEmail.Text = "Send Email"; // Translated text for the checkbox
            this.cbEmail.UseVisualStyleBackColor = true;
            // 
            // cbSMS
            // 
            this.cbSMS.AutoSize = true;
            this.cbSMS.Location = new System.Drawing.Point(12, 35);
            this.cbSMS.Name = "cbSMS";
            this.cbSMS.Size = new System.Drawing.Size(83, 17);
            this.cbSMS.TabIndex = 1;
            this.cbSMS.Text = "Send SMS"; // Translated text for the checkbox
            this.cbSMS.UseVisualStyleBackColor = true;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 58);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(360, 100);
            this.txtMessage.TabIndex = 2;
            this.txtMessage.PlaceholderText = "Enter your message here"; // Requires .NET 6 or higher
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(12, 164);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Send"; // Translated text for the button
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.cbSMS);
            this.Controls.Add(this.cbEmail);
            this.Name = "Form1";
            this.Text = "Notification App"; // Translated title for the form
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

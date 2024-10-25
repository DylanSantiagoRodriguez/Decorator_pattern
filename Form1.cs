using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace NotificationDecoratorApp
{
    public partial class Form1 : Form
    {
        private const string AccountSid = "AC3e1ab34e80490c475515b1accc60934d"; // Your Twilio Account SID
        private const string AuthToken = "98882f00245b36dfda9090e6110958d0"; // Your Auth Token
        private const string TwilioNumber = "+17604900669"; // Your Twilio number

        private System.Windows.Forms.TextBox? txtRecipientEmail; // Declaration of the field as nullable

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents(); // Method to initialize custom components
        }

        private void InitializeCustomComponents()
        {
            // Initializes the TextBox for the email
            this.txtRecipientEmail = new System.Windows.Forms.TextBox();
            this.txtRecipientEmail.Location = new System.Drawing.Point(12, 180);
            this.txtRecipientEmail.Name = "txtRecipientEmail";
            this.txtRecipientEmail.Size = new System.Drawing.Size(360, 20);
            this.txtRecipientEmail.TabIndex = 5;
            this.txtRecipientEmail.PlaceholderText = "Enter the recipient's email"; // Requires .NET 6 or higher
            this.Controls.Add(this.txtRecipientEmail);
        }

        private async void sendButton_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text;
            bool sendEmail = cbEmail.Checked; // Make sure you have this checkbox on your form
            bool sendSMS = cbSMS.Checked; // Make sure you have this checkbox on your form

            // Send email if the option is selected
            if (sendEmail)
            {
                // Check if txtRecipientEmail is not null
                if (txtRecipientEmail != null)
                {
                    string recipientEmail = txtRecipientEmail.Text;
                    if (string.IsNullOrWhiteSpace(recipientEmail))
                    {
                        MessageBox.Show("Please enter a valid email address.");
                        return;
                    }
                    SendEmail(recipientEmail, message);
                }
                else
                {
                    MessageBox.Show("The email field is not initialized.");
                }
            }

            // Send SMS if the option is selected
            if (sendSMS)
            {
                string recipientPhoneNumber = "+18777804236"; // Change this according to the number you want to send
                await SendSMSAsync(recipientPhoneNumber, message);
            }
        }

        private void SendEmail(string toEmail, string message)
        {
            try
            {
                // Configure the SMTP client
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("preyas.dylan@gmail.com", "xinx aqyz vxuo gvnt"); // Replace with your credentials

                    // Create the message
                    MailMessage mailMessage = new MailMessage
                    {
                        From = new MailAddress("preyas.dylan@gmail.com"),
                        Subject = "Notification",
                        Body = message
                    };
                    mailMessage.To.Add(toEmail);

                    // Send the email
                    client.Send(mailMessage);
                    MessageBox.Show("Email sent successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}");
            }
        }

        private async Task SendSMSAsync(string to, string message)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var values = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("To", to),
                        new KeyValuePair<string, string>("From", TwilioNumber),
                        new KeyValuePair<string, string>("Body", message),
                    });

                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{AccountSid}:{AuthToken}")));

                    // Send the POST request
                    var response = await client.PostAsync("https://api.twilio.com/2010-04-01/Accounts/" + AccountSid + "/Messages.json", values);
                    response.EnsureSuccessStatusCode(); // Throws an exception if the request is not successful

                    MessageBox.Show("SMS sent successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending SMS: {ex.Message}");
            }
        }
    }
}

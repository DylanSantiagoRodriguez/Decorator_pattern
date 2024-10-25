public class EmailNotification : INotification
{
    private readonly INotification _notification;

    public EmailNotification(INotification notification)
    {
        _notification = notification;
    }

    public void Send(string message)
    {
        _notification.Send(message);
        MessageBox.Show("Email Notification: " + message);
    }
}

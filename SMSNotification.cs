public class SMSNotification : INotification
{
    private readonly INotification _notification;

    public SMSNotification(INotification notification)
    {
        _notification = notification;
    }

    public void Send(string message)
    {
        _notification.Send(message);

        MessageBox.Show("SMS Notification: " + message);
    }
}

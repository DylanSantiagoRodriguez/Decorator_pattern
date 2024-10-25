public class BasicNotification : INotification
{
    public void Send(string message)
    {
        MessageBox.Show("Basic Notification: " + message);
    }
}

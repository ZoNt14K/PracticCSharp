public class EmailSubscriber : INewsSubscriber
{
    private string _email;

    public EmailSubscriber(string email)
    {
        _email = email;
    }

    public void Update(string news)
    {
        Console.WriteLine($"[Email -> {_email}]: Получено уведомление: {news}");
    }
}

public class MobileSubscriber : INewsSubscriber
{
    private string _phoneNumber;

    public MobileSubscriber(string phoneNumber)
    {
        _phoneNumber = phoneNumber;
    }

    public void Update(string news)
    {
        Console.WriteLine($"[SMS -> {_phoneNumber}]: Внимание! Новое в ленте: {news}");
    }
}
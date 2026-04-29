class Program
{
    static void Main()
    {
        NewsPublisher techNews = new NewsPublisher();

        var emailUser = new EmailSubscriber("ivan@example.com");
        var phoneUser = new MobileSubscriber("+375-29-123-45-67");

        techNews.Subscribe(emailUser);
        techNews.Subscribe(phoneUser);

        techNews.PublishNews("Вышла новая версия Fedora GNOME!");

        techNews.Unsubscribe(emailUser);

        techNews.PublishNews("В Arch Linux обновили ядро.");
    }
}
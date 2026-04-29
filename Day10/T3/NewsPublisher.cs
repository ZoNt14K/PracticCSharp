using System;
using System.Collections.Generic;

public class NewsPublisher
{
    private List<INewsSubscriber> _subscribers = new List<INewsSubscriber>();
    private string _latestNews;

    public void Subscribe(INewsSubscriber subscriber)
    {
        _subscribers.Add(subscriber);
        Console.WriteLine("[Система] Добавлен новый подписчик.");
    }

    public void Unsubscribe(INewsSubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
        Console.WriteLine("[Система] Подписчик удален.");
    }

    public void NotifySubscribers()
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(_latestNews);
        }
    }

    public void PublishNews(string news)
    {
        _latestNews = news;
        Console.WriteLine($"\n[Издатель] Публикует новость: {news}");
        NotifySubscribers();
    }
}
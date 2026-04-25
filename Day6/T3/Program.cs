using System;

namespace OrderSystem
{
    public delegate void OrderHandler(int orderId, double price);

    public class OrderManager
    {
        public event OrderHandler OrderPlaced;

        public void CreateOrder(int id, double amount)
        {
            Console.WriteLine($"[OrderManager]: Заказ №{id} на сумму {amount:C} сформирован.");

            if (OrderPlaced != null)
            {
                OrderPlaced(id, amount);
            }
        }
    }

    public class EmailNotifier
    {
        public void OnOrderPlaced(int id, double price)
        {
            Console.WriteLine($"[Email Notifier]: Отправка письма... Заказ #{id} подтвержден. Списано: {price:C}");
        }
    }

    public class SmsNotifier
    {
        public void SendSms(int id, double price)
        {
            Console.WriteLine($"[SMS Notifier]: СМС: Заказ #{id} готов! К оплате: {price:C}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OrderManager manager = new OrderManager();
            EmailNotifier emailService = new EmailNotifier();
            SmsNotifier smsService = new SmsNotifier();

            manager.OrderPlaced += emailService.OnOrderPlaced;
            manager.OrderPlaced += smsService.SendSms;

            Console.WriteLine("--- Обработка нового заказа ---");
            manager.CreateOrder(101, 2500.50);

            Console.WriteLine("\n--- Отписка SMS-уведомлений ---");
            manager.OrderPlaced -= smsService.SendSms;

            Console.WriteLine("--- Обработка еще одного заказа ---");
            manager.CreateOrder(102, 499.00);

            Console.ReadKey();
        }
    }
}
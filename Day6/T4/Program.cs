using System;

namespace OrderSystemEventHandler
{
    public class OrderManager
    {
        public event EventHandler<OrderEventArgs> OrderPlaced;

        public void PlaceOrder(int id, double amount)
        {
            Console.WriteLine($"[OrderManager]: Оформление заказа №{id}...");

            OnOrderPlaced(new OrderEventArgs(id, amount));
        }

        protected virtual void OnOrderPlaced(OrderEventArgs e)
        {
            OrderPlaced?.Invoke(this, e);
        }
    }

    public class EmailService
    {
        public void SendEmail(object sender, OrderEventArgs e)
        {
            Console.WriteLine($"[Email Service]: Письмо отправлено. Заказ №{e.OrderId} на сумму {e.Amount:C}.");
        }
    }

    public class SmsService
    {
        public void SendSms(object sender, OrderEventArgs e)
        {
            Console.WriteLine($"[Sms Service]: SMS отправлено. Заказ №{e.OrderId} подтвержден.");
        }
    }

    public class OrderNotifier
    {
        public OrderNotifier(OrderManager manager, EmailService email, SmsService sms)
        {
            manager.OrderPlaced += email.SendEmail;
            manager.OrderPlaced += sms.SendSms;
            
            Console.WriteLine("[OrderNotifier]: Все сервисы уведомлений успешно подключены к OrderManager.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OrderManager orderManager = new OrderManager();
            EmailService email = new EmailService();
            SmsService sms = new SmsService();

            OrderNotifier notifier = new OrderNotifier(orderManager, email, sms);

            Console.WriteLine("\n--- Имитация работы системы ---");
            orderManager.PlaceOrder(5001, 1250.75);
            
            orderManager.PlaceOrder(5002, 340.00);

            Console.ReadKey();
        }
    }
}
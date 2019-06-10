using System;
using Redbus.Events;
using Redbus.Interfaces;

namespace Redbus.Demo.Net45.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IEventBus eventBus = new EventBus();
            eventBus.Subscribe<PayloadEvent<int>>(OnIntEvent);
            eventBus.Subscribe<CustomEventClass>(OnCustomEvent);

            eventBus.Publish(new PayloadEvent<int>(5)); // OnIntEvent will be invoked
            eventBus.Publish(new CustomEventClass()); // OnCustomEvent will be invoked


            eventBus.Subscribe<PayloadEvent<string>>(s =>
            {
                Console.WriteLine(s.Payload);
            });

            eventBus.Publish(new PayloadEvent<string>("Hello"));

            Console.ReadKey();
        }

        private static void OnCustomEvent(CustomEventClass customEvent)
        {
            Console.WriteLine("Received CustomEvent");
        }

        private static void OnIntEvent(PayloadEvent<int> intEvent)
        {
            Console.WriteLine(intEvent.Payload);
        }
    }

    class CustomEventClass : EventBase
    {
    }
}

using System;
using System.Diagnostics;

namespace Redbus.Tests
{
    internal class TestSubscriber : IDisposable
    {
        private bool _isDisposed;
        private object _disposeLock;

        public SubscriptionToken DoSubscribe(EventBus bus)
        {
            return bus.Subscribe<CustomTestEvent>(s =>
            {
                PrintMessage($"Received event \"{s.Name}\"");
            });
        }

        private void PrintMessage(string message)
        {
            Debug.Print($"Subscriber [{GetHashCode()}]: {message}");
        }

        public TestSubscriber()
        {
            _disposeLock = new object();
            Debug.Print($"Subscriber [{GetHashCode()}] created");
        }

        ~TestSubscriber()
        {
            if (!_isDisposed)
                Dispose();
            Debug.Print($"Subscriber [{GetHashCode()}] freed (nominally not called)");
        }

        public void Dispose()
        {
            if (_isDisposed)
                return;

            lock (_disposeLock)
            {
                _isDisposed = true;
                Debug.Print($"Subscriber [{GetHashCode()}] disposed");
                GC.SuppressFinalize(this);
            }
        }

    }
}

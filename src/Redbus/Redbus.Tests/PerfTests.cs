using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Redbus.Tests
{
    [TestClass]
    public class PerfTests
    {
        // Naive baseline to see changes for now

        [TestMethod]
        public void NaivePublishPerformanceTest()
        {
            var eventBus = new EventBus();
            eventBus.Subscribe<CustomTestEvent>(CustomTestEventHandler);

            var sw = Stopwatch.StartNew();
            for (int i = 0; i < 1000000; i++)
            {
                eventBus.Publish(new CustomTestEvent { Name = "Custom Event", Identifier = 1 });
            }
            sw.Stop();

            Debug.WriteLine($"Finished in {sw.ElapsedMilliseconds}ms");
            Assert.IsTrue(sw.Elapsed < TimeSpan.FromSeconds(1), $"NaivePublishPerformanceTest took {sw.ElapsedMilliseconds}ms");
            
            Console.WriteLine($"[DEBUG] NaivePublishPerformanceTest took {sw.ElapsedMilliseconds}ms");
        }

        [TestMethod]
        public void NaiveConcurrentPublishPerformanceTest()
        {
            var eventBus = new EventBus();
            eventBus.Subscribe<CustomTestEvent>(CustomTestEventHandler);

            var mainSw = Stopwatch.StartNew();
            var threads = new List<Thread>();
            for (int i = 0; i < 10; i++)
            {
                var thread = new Thread(() =>
                {
                    var sw = Stopwatch.StartNew();
                    for (int j = 0; j < 100; j++)
                    {
                        eventBus.Publish(new CustomTestEvent { Name = "Custom Event", Identifier = 1 });
                    }
                    sw.Stop();
                    Assert.IsTrue(sw.Elapsed < TimeSpan.FromSeconds(1), $"NaivePublishPerformanceTest took {sw.ElapsedMilliseconds}ms");
                });

                threads.Add(thread);
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
            mainSw.Stop();
            Assert.IsTrue(mainSw.Elapsed < TimeSpan.FromSeconds(2), $"NaivePublishPerformanceTest took {mainSw.ElapsedMilliseconds}ms");

        }

        private void CustomTestEventHandler(CustomTestEvent customTestEvent)
        {
            Thread.Sleep(10);
        }
    }
}

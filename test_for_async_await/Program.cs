using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace test_for_async_await
{
    class Program
    {
        static void Log(int num, string msg)
        {
            Console.WriteLine("({0}) T{1}: {2}",
                num, Thread.CurrentThread.ManagedThreadId, msg);
        }

        static async Task Main()
        {
            Log(1, "start MyDownloadPageAsync()。");

            var task = MyDownloadPageAsync("https://www.huanlintalk.com");
            var task2 = MyDownloadPageAsync2("https://www.google.com.tw");

            Log(4, " MyDownloadPageAsync() return, result not yet");

            string content2 = await task2;
            Log(99, "check wait task");
            string content = await task;

            Log(6, " MyDownloadPageAsync() result get");

            Console.WriteLine("total {0} char", content.Length);
            Console.WriteLine("2total {0} char", content2.Length);
        }

        static async Task<string> MyDownloadPageAsync(string url)
        {
            Log(2, "calling WebClient.DownloadStringTaskAsync()。");

            using (var webClient = new WebClient())
            {
                var task = webClient.DownloadStringTaskAsync(url);

                Log(3, "async task start DownloadStringTaskAsync()。");

                string content = await task;

                Log(5, " DownloadStringTaskAsync() result get");

                return content;
            }
        }

        static async Task<string> MyDownloadPageAsync2(string url)
        {
            Log(2, "calling WebClient.DownloadStringTaskAsync2()。");

            using (var webClient = new WebClient())
            {
                var task = webClient.DownloadStringTaskAsync(url);

                Log(3, "async task start DownloadStringTaskAsync()2");

                string content = await task;

                Log(5, " DownloadStringTaskAsync()2 result get");

                return content;
            }
        }
    }
}

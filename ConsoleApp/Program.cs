using System.Diagnostics;

namespace ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            do
            {
                AddLog("App is running...\n");
                Console.WriteLine("Request Type (Sync = 1, Async = 2): \n ");
                int requestType = int.Parse(Console.ReadLine());

                Console.WriteLine("How many request: \n");
                int requestCount = int.Parse(Console.ReadLine());

                var webApiClient = new WebApiClient();

                var sw = Stopwatch.StartNew();

                var task = requestType == 1 ? GetSyncTasks(requestCount): GetAsyncTasks(requestCount);

                await Task.WhenAll(task);

                sw.Stop();

                AddLog($"Total time:  {sw.ElapsedMilliseconds} MS \n");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        public static IEnumerable<Task> GetSyncTasks(int howMany)
        {
            var result = new List<Task>();

            WebApiClient webApiClient = new WebApiClient();

            for (int i = 0; i < howMany; i++)
            {
                result.Add(webApiClient.CallSync());
            }

            return result;
        }

        public static IEnumerable<Task> GetAsyncTasks(int howMany)
        {
            var result = new List<Task>();

            WebApiClient webApiClient = new WebApiClient();

            for (int i = 0; i < howMany; i++)
            {
                result.Add(webApiClient.CallAsync());
            }

            return result;
        }

        private static void AddLog(string logStr)
        {
            logStr = $"[{DateTime.Now:dd.MM.yy}] - {logStr} \n";
            Console.WriteLine(logStr);
        }
    }   
}

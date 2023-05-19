namespace HomeCare.Services
{
    public class DatabaseCheckService : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(TimeSpan.FromSeconds(10));
            while (!stoppingToken.IsCancellationRequested)
            {
                if (await timer.WaitForNextTickAsync(stoppingToken))
                {
                    Console.WriteLine("Checking database...");
                    // 检查数据库代码
                }
            }
        }
    }
}

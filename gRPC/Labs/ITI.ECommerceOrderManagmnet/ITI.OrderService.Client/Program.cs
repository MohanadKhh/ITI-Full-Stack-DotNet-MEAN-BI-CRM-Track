namespace ITI.OrderService.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Order Id: ");
            int OrderId = int.Parse(Console.ReadLine());

            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddHostedService<Worker>(svc =>
            {
                var logger = svc.GetRequiredService<ILogger<Worker>>();
                var hostLifetime = svc.GetRequiredService<IHostApplicationLifetime>();
                return new Worker(logger, hostLifetime, OrderId);
            });

            var host = builder.Build();
            host.Run();
        }
    }
}

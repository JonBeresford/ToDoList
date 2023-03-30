using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = new HostBuilder()
               .ConfigureWebHost(builder =>
               {
                   builder
                       .UseKestrel()
                       .UseStartup<Startup>();
               })
               .Build();

            await host.RunAsync();
        }

      
    }
}

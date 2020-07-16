
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using centiro_anstallning.Services;

namespace centiro_anstallning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ReadParseSave.DeserializeSerialize();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

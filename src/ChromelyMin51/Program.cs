using Chromely;
using Chromely.Core;
using Chromely.Core.Configuration;
using Chromely.Core.Host;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace ChromelyMin51
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var config = DefaultConfiguration.CreateForRuntimePlatform();
            config.WindowOptions = new WindowOptions
            {
                Title = "ChromelyMin51",
                StartCentered = true,
                Size = new WindowSize(800, 600),
                RelativePathToIconFile = "chromely.ico",
                WindowFrameless = true,
                FramelessOption = new FramelessOption
                {
                    UseWebkitAppRegions = true
                }
            };

            AppBuilder
                .Create()
                .UseConfig<DefaultConfiguration>(config)
                .UseApp<App>()
                .Build()
                .Run(args);
        }
    }

    public class App : ChromelyBasicApp
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.AddLogging(configure => configure.AddConsole());
            services.AddSingleton<IChromelyNativeHost, CustomChromelyWinFramelessHost>();

            RegisterControllerAssembly(services, typeof(App).Assembly);
        }
    }
}
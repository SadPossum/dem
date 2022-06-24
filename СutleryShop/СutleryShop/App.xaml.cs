using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using СutleryShop.Comands;
using СutleryShop.Stores;
using СutleryShop.ViewModels;
using СutleryShop.Views;

namespace СutleryShop
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<NavigationStore>()
                        .AddSingleton<ShopViewModel>()
                        .AddSingleton<ProductViewModel>()
                        .AddSingleton<AuthViewModel>()
                        .AddSingleton<MainViewModel>()
                        .AddSingleton(s => new NavigateCommand<ShopViewModel>(s.GetRequiredService<NavigationStore>(),
                            s.GetRequiredService<ShopViewModel>))
                        .AddSingleton(s => new NavigateCommand<ProductViewModel>(s.GetRequiredService<NavigationStore>(),
                            s.GetRequiredService<ProductViewModel>))
                        .AddSingleton(s => new NavigateCommand<AuthViewModel>(s.GetRequiredService<NavigationStore>(),
                            s.GetRequiredService<AuthViewModel>))
                        .AddSingleton(s => new MainView(s.GetRequiredService<MainViewModel>()));
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            NavigationStore navigationStore = _host.Services.GetRequiredService<NavigationStore>();
            navigationStore.CurentViewModel = _host.Services.GetRequiredService<AuthViewModel>();

            MainView mainWindow = _host.Services.GetRequiredService<MainView>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync();
            }

            base.OnExit(e);
        }
    }
}

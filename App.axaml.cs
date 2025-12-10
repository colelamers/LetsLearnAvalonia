using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using LetsLearnAvalonia.ViewModels;
using LetsLearnAvalonia.Views;
using Microsoft.Extensions.DependencyInjection;
using LetsLearnAvalonia.Factories;
using System;
using LetsLearnAvalonia.Data;

namespace LetsLearnAvalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        ServiceCollection collection = new ServiceCollection();
        collection.AddTransient<MainWindowViewModel>();
        collection.AddTransient<HomePageViewModel>();
        collection.AddTransient<ProcessPageViewModel>();
        collection.AddTransient<ActionsPageViewModel>();
        collection.AddTransient<MacrosPageViewModel>();
        collection.AddTransient<ReporterPageViewModel>();
        collection.AddTransient<HistoryPageViewModel>();
        collection.AddTransient<SettingsPageViewModel>();

        // NOTE: The only reason in the tutorial he could use "name" instead of
        // pageName is because that is a new C# 9 feature. We have to use 
        // "pageName" here. I would never use that feature anyway because it
        // abstracts WAY too much away and you have no idea in context what name
        // is because it exists nowhere else in the code but here.
        // todo 2; I absolutely want to refactor the DI code so that not only
        // is it readable, but you actually can debug it too.
        collection.AddSingleton<Func<ApplicationPageNames, PageViewModel>>(
            x => pageName => pageName switch
            {
                ApplicationPageNames.Home => x.GetRequiredService<HomePageViewModel>(),
                ApplicationPageNames.Process => x.GetRequiredService<ProcessPageViewModel>(),
                ApplicationPageNames.Actions => x.GetRequiredService<ActionsPageViewModel>(),
                ApplicationPageNames.Macros => x.GetRequiredService<MacrosPageViewModel>(),
                ApplicationPageNames.Reporter => x.GetRequiredService<ReporterPageViewModel>(),
                ApplicationPageNames.History => x.GetRequiredService<HistoryPageViewModel>(),
                ApplicationPageNames.Settings => x.GetRequiredService<SettingsPageViewModel>(),
                _ => throw new ArgumentException("The PageName does not have a ViewModel.", nameof(pageName)),
            });

        collection.AddSingleton<PageFactory>();

        ServiceProvider services = collection.BuildServiceProvider();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new MainWindow
            {
                DataContext = services.GetRequiredService<MainWindowViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}

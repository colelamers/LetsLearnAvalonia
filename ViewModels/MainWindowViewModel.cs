
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LetsLearnAvalonia.Factories;
using LetsLearnAvalonia.Data;
namespace LetsLearnAvalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private PageFactory? _pageFactory;
    // This is functioanlly equivalent to my status-message-binding feature.
    // As a note, the "{Binding ...}" ignores "_" and casing so you must always
    // write the binding as a PascalCase version of the property.

    [ObservableProperty]
    private bool _sideMenuExpanded = false;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HomePageIsActive))]
    [NotifyPropertyChangedFor(nameof(ProcessPageIsActive))]
    [NotifyPropertyChangedFor(nameof(ActionsPageIsActive))]
    [NotifyPropertyChangedFor(nameof(MacrosPageIsActive))]
    [NotifyPropertyChangedFor(nameof(ReporterPageIsActive))]
    [NotifyPropertyChangedFor(nameof(HistoryPageIsActive))]
    [NotifyPropertyChangedFor(nameof(SettingsPageIsActive))]
    private PageViewModel? _currentPage;

    public bool HomePageIsActive => CurrentPage!.PageName == ApplicationPageNames.Home;
    public bool ProcessPageIsActive => CurrentPage!.PageName == ApplicationPageNames.Process;
    public bool ActionsPageIsActive => CurrentPage!.PageName == ApplicationPageNames.Actions;
    public bool MacrosPageIsActive => CurrentPage!.PageName == ApplicationPageNames.Macros;
    public bool ReporterPageIsActive => CurrentPage!.PageName == ApplicationPageNames.Reporter;
    public bool HistoryPageIsActive => CurrentPage!.PageName == ApplicationPageNames.History;
    public bool SettingsPageIsActive => CurrentPage!.PageName == ApplicationPageNames.Settings;

    /// <summary>
    /// Design time constructor
    /// </summary>
    public MainWindowViewModel()
    {
        CurrentPage = new SettingsPageViewModel();
    }

    // This HomePageViewModel is a dependency injection from th eApp.axaml.cs
    // collection.AddSingleton<HomePageViewModel>(); By adding that service,
    // item, we can then have it injected here.
    public MainWindowViewModel(PageFactory pageFactory)
    {
        _pageFactory = pageFactory;
        GoToHome();

    }

    [RelayCommand]
    private void SideMenuResize() => SideMenuExpanded = !SideMenuExpanded;
    
    [RelayCommand]
    private void GoToHome() => CurrentPage = _pageFactory!.GetPageViewModel(ApplicationPageNames.Home);
    
    [RelayCommand]
    private void GoToProcess() => CurrentPage = _pageFactory!.GetPageViewModel(ApplicationPageNames.Process);
    
    [RelayCommand]
    private void GoToActions() => CurrentPage = _pageFactory!.GetPageViewModel(ApplicationPageNames.Actions);
    
    [RelayCommand]
    private void GoToMacros() => CurrentPage = _pageFactory!.GetPageViewModel(ApplicationPageNames.Macros);
    
    [RelayCommand]
    private void GoToReporter() => CurrentPage = _pageFactory!.GetPageViewModel(ApplicationPageNames.Reporter);
    
    [RelayCommand]
    private void GoToHistory() => CurrentPage = _pageFactory!.GetPageViewModel(ApplicationPageNames.History);

    [RelayCommand]
    private void GoToSettings() => CurrentPage = _pageFactory!.GetPageViewModel(ApplicationPageNames.Settings);
}

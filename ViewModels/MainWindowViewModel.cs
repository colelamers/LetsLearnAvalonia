
using System;
using Avalonia.Svg.Skia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LetsLearnAvalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    // This is functioanlly equivalent to my status-message-binding feature.
    // As a note, the "{Binding ...}" ignores "_" and casing so you must always
    // write the binding as a PascalCase version of the property.
    [ObservableProperty]
    private string _title = "Lets Learn Avalonia!";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(SideMenuImage))]
    private bool _sideMenuExpanded = false;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(HomePageIsActive))]
    [NotifyPropertyChangedFor(nameof(ProcessPageIsActive))]
    [NotifyPropertyChangedFor(nameof(ActionsPageIsActive))]
    [NotifyPropertyChangedFor(nameof(MacrosPageIsActive))]
    [NotifyPropertyChangedFor(nameof(ReporterPageIsActive))]
    [NotifyPropertyChangedFor(nameof(HistoryPageIsActive))]
    private ViewModelBase _currentPage;
    public SvgImage SideMenuImage => new SvgImage 
    {
        Source = SvgSource.Load($"avares://{nameof(LetsLearnAvalonia)}/Assets/images" +
         $"/{(SideMenuExpanded ? "logo" : "icon")}.svg"),
    };
    
    public bool HomePageIsActive => CurrentPage == _homePage;
    public bool ProcessPageIsActive => CurrentPage == _processPage;
    public bool ActionsPageIsActive => CurrentPage == _actionsPage;
    public bool MacrosPageIsActive => CurrentPage == _macrosPage;
    public bool ReporterPageIsActive => CurrentPage == _reporterPage;
    public bool HistoryPageIsActive => CurrentPage == _historyPage;
    private readonly HomePageViewModel _homePage = new();
    private readonly ProcessPageViewModel _processPage = new();
    private readonly ActionsPageViewModel _actionsPage = new();
    private readonly MacrosPageViewModel _macrosPage = new();
    private readonly ReporterPageViewModel _reporterPage = new();
    private readonly HistoryPageViewModel _historyPage = new();

    public MainWindowViewModel()
    {
        CurrentPage = _processPage;
    }

    [RelayCommand]
    private void SideMenuResize()
    {
        SideMenuExpanded = !SideMenuExpanded;
    }
    
    [RelayCommand]
    private void GoToHome() => CurrentPage = _homePage;
    
    [RelayCommand]
    private void GoToProcess() => CurrentPage = _processPage;
    
    [RelayCommand]
    private void GoToActions() => CurrentPage = _actionsPage;
    
    [RelayCommand]
    private void GoToMacros() => CurrentPage = _macrosPage;
    
    [RelayCommand]
    private void GoToReporter() => CurrentPage = _reporterPage;
    
    [RelayCommand]
    private void GoToHistory() => CurrentPage = _historyPage;
}

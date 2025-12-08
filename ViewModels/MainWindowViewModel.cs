
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
    
    public SvgImage SideMenuImage => new SvgImage 
    {
        Source = SvgSource.Load($"avares://{nameof(LetsLearnAvalonia)}/Assets/images/{(SideMenuExpanded ? "logo" : "icon")}.svg"),
    };
    [RelayCommand]
    private void SideMenuResize()
    {
        SideMenuExpanded = !SideMenuExpanded;
    }
}

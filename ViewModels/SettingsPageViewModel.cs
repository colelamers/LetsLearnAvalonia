using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LetsLearnAvalonia.ViewModels;

public partial class SettingsPageViewModel : PageViewModel
{
    [ObservableProperty]
    private List<string> _locationPaths;

    public SettingsPageViewModel()
    {
        base.PageName = Data.ApplicationPageNames.Settings; 
        // TEMP: Remove
        LocationPaths = new List<string>()
        {
            @"C:\Full\Path\Here",
            @"/usr/share/",
            @"D:\Some\Other\Drive\Path"
        };
    }
}

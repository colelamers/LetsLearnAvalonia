namespace LetsLearnAvalonia.ViewModels;

public partial class SettingsPageViewModel : PageViewModel
{
    public string Test {get; set;} = "SettingsPageViewModel";
    public SettingsPageViewModel()
    {
        base.PageName = Data.ApplicationPageNames.Settings; 
    }
}

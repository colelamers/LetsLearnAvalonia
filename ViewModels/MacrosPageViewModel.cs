namespace LetsLearnAvalonia.ViewModels;

public partial class MacrosPageViewModel : PageViewModel
{
    public string Test {get; set;} = "MacrosPageViewModel";
    public MacrosPageViewModel()
    {
        base.PageName = Data.ApplicationPageNames.Macros; 
    }
}

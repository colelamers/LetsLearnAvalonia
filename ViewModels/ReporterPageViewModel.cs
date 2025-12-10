namespace LetsLearnAvalonia.ViewModels;

public partial class ReporterPageViewModel : PageViewModel
{
    public string Test {get; set;} = "ReporterPageViewModel";
    public ReporterPageViewModel()
    {
        base.PageName = Data.ApplicationPageNames.Reporter; 
    }
}

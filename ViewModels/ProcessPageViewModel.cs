namespace LetsLearnAvalonia.ViewModels;

public partial class ProcessPageViewModel : PageViewModel
{
    public string Test {get; set;} = "ProcessPageViewModel";
    public ProcessPageViewModel()
    {
        base.PageName = Data.ApplicationPageNames.Process; 
    }
}

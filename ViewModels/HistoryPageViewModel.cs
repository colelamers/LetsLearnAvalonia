namespace LetsLearnAvalonia.ViewModels;

public partial class HistoryPageViewModel : PageViewModel
{
    public string Test {get; set;} = "HistoryPageViewModel";
    public HistoryPageViewModel()
    {
        base.PageName = Data.ApplicationPageNames.History; 
    }
}

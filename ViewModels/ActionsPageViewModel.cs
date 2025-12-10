namespace LetsLearnAvalonia.ViewModels;

public partial class ActionsPageViewModel : PageViewModel
{
    public string Test {get; set;} = "ActionsPageViewModel";
    public ActionsPageViewModel()
    {
        base.PageName = Data.ApplicationPageNames.Actions; 
    }
}

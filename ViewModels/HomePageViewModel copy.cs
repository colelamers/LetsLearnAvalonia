namespace LetsLearnAvalonia.ViewModels;

public partial class HomePageViewModel : PageViewModel
{
    public string Test {get; set;} = "HomePageViewModel";
    public HomePageViewModel()
    {
        base.PageName = Data.ApplicationPageNames.Home; 
    }
}

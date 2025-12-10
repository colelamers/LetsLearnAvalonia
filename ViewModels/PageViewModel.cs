using LetsLearnAvalonia.Data;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LetsLearnAvalonia.ViewModels;

public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty]
    private ApplicationPageNames _pageName;
}

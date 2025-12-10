using System;
using LetsLearnAvalonia.Data;
using LetsLearnAvalonia.ViewModels;

namespace LetsLearnAvalonia.Factories;

// C# RAII :D, although hmm, not like the .hpp and .cpp split. I am torn.
public class PageFactory(Func<ApplicationPageNames, PageViewModel> factory)
{
    public PageViewModel GetPageViewModel(ApplicationPageNames pageName) => factory.Invoke(pageName);
}

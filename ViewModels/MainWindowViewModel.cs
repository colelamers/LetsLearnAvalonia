using System;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using LetsLearnAvalonia.Models;

namespace LetsLearnAvalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
{
    // Note: ICommand is required to bind a function call to a "Command"
    // property within the view. This setup I have here allows for an OOP
    // approach to dealing with it in case you need more than just a simple
    // string.
    public ICommand Click_btnTop { get; private set; } 
    public ICommand Click_btnBottom { get; private set; } 
    public StatusMessage StatusMessage { get; set; } = new StatusMessage()
    {
        Message = "Ready",
        DoNotMonitor = "Ignore Me"
    };
    public StatusMessage OtherMessage { get; set; } = new StatusMessage()
    {
        Message = "Also Ready",
        DoNotMonitor = "I am the galactic inquisitor."
    };
    
    public MainWindowViewModel()
    {
        // Initialize the command in the constructor, linking it to a method
        Click_btnTop = new RelayCommand(ClickTop); 
        Click_btnBottom = new RelayCommand(ClickBottom); 
    }

    // The method that gets executed when the button is pressed
    private void ClickTop()
    {
        StatusMessage.DoNotMonitor = "Top button pressed at " + DateTime.Now.ToLongTimeString();
    }
    
    private void ClickBottom()
    {
        OtherMessage.Message = "Bottom button pressed at " + DateTime.Now.ToLongTimeString();
    }
}

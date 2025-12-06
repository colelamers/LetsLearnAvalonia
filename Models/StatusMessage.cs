using System;
using System.ComponentModel;

namespace LetsLearnAvalonia.Models;

/// <summary>
/// A simple model class that holds a status message string. This is an example
/// of how to bind parts of an object, but not the whole thing to a view. This
/// could be used if you are modifying configs, updating 
/// Implements INotifyPropertyChanged to notify the view of changes.
/// </summary>
public class StatusMessage : INotifyPropertyChanged
{
    private string _message {get; set;} = "";
    public string DoNotMonitor { get; set; } = "";
    public required string Message
    {
        get => _message;
        set
        {
            if (_message != value)
            {
                _message = value;
                // Fires the custom event when the internal value changes. If
                // you wish for other objects to be monitored, you can just add
                // more PropertyChanged?.Invoke(...) in a similar fashion to 
                // that object.
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Message)));
            }
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged; 
}

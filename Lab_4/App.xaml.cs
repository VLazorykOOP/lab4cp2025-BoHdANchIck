using Lab_4.Windows;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Lab_4;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        new LoginWindow().Show();
    }

}


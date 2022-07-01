using MonkeysApp.Views;

namespace MonkeysApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(DetailsView), typeof(DetailsView));
    }
}

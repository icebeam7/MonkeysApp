using MonkeysApp.ViewModels;

namespace MonkeysApp.Views;

public partial class MonkeysView : ContentPage
{
	public MonkeysView(MonkeyViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}
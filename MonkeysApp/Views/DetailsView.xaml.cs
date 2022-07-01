using MonkeysApp.ViewModels;

namespace MonkeysApp.Views;

public partial class DetailsView : ContentPage
{
	public DetailsView(MonkeyDetailsViewModel vm)
	{
        InitializeComponent();
        BindingContext = vm;
    }
}
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MonkeysApp.Models;
using System.Diagnostics;

namespace MonkeysApp.ViewModels
{
    [QueryProperty(nameof(Monkey), "Monkey")]
    public partial class MonkeyDetailsViewModel : BaseViewModel
    {

        IMap map;
        public MonkeyDetailsViewModel(IMap map)
        {
            this.map = map;
        }

        [ObservableProperty]
        Monkey monkey;

        [RelayCommand]
        async Task OpenMap()
        {
            try
            {
                await map.OpenAsync(Monkey.Latitude, Monkey.Longitude, new MapLaunchOptions
                {
                    Name = Monkey.Name,
                    NavigationMode = NavigationMode.None
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to launch maps: {ex.Message}");
                await Shell.Current.DisplayAlert("Error, no Maps app!", ex.Message, "OK");
            }
        }
    }
}

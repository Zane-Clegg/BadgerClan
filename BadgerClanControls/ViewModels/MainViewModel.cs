using BadgerClanControls.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BadgerClanControls.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IApiService apiService;

        [ObservableProperty]
        private string current;

        public MainViewModel(IApiService api)
        {
            apiService = api ?? throw new ArgumentNullException(nameof(api));
            current = "Nothing";
        }

        [RelayCommand]
        private async Task SetPath(string pathing)
        {
            current = pathing;
            await apiService.SetApiAsync(pathing);
        }
    }
}

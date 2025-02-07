using BadgerClanControls.Models;
using BadgerClanControls.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace BadgerClanControls.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IApiService apiService;

        public ObservableCollection<ApiSelectionModel> ApiSelections { get; set; } = new ObservableCollection<ApiSelectionModel>();

        [ObservableProperty]
        private string current = "nothing";

        [ObservableProperty]
        private string apiUrl;

        [ObservableProperty]
        private string apiName;

        [ObservableProperty]
        private string errorMessage;

        public MainViewModel(IApiService api)
        {
            apiService = api ?? throw new ArgumentNullException(nameof(api));
            current = "Nothing";
        }

        [RelayCommand]
        private async Task SetPath(string pathing)
        {
            current = pathing;
            await apiService.SetApiAsync(apiUrl,pathing);
        }

        [RelayCommand]
        private async Task SubmitApi()
        {
            ErrorMessage = string.Empty;
            string pathing = "";
            try
            {
                var message = await apiService.SetApiAsync(ApiUrl.TrimEnd('/'), pathing);
                if (message.Error != null) 
                {
                    ErrorMessage = message.Error;
                }
            }
            catch (Exception ex) 
            {
                ErrorMessage = ex.Message.ToString();
            }
        }
    }
}

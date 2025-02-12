using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BadgerClanControls.ViewModels
{
    public partial class ApiViewModel : ObservableObject
    {
        [ObservableProperty]
        private string apiUrl;
        [ObservableProperty]
        private string apiName;
        [ObservableProperty]
        private bool isSelected;
        public ApiViewModel(string _apiName, string _apiUrl)
        {
            apiUrl = _apiUrl;
            apiName = _apiName;
            isSelected = false;
        }
    }
}

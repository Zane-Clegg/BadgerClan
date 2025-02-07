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
        public string ApiUrl { get; set; }
        public string ApiName { get; set; }
        [ObservableObject]
        public bool isSelected { get; set; }
        public ApiViewModel(string apiName, string apiUrl)
        {
            ApiUrl = apiUrl;
            ApiName = apiName;
            isSelected = false;
        }
    }
}

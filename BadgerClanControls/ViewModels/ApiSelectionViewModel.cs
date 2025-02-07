using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgerClanControls.ViewModels
{
    public partial class ApiSelectionModel : ObservableObject
    {
        public string ApiName { get; set; }

        public ApiSelectionModel(string apiName)
        {
            ApiName = apiName;
        }
    }
}

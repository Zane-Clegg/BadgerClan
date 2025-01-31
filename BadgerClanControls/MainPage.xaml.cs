using BadgerClanControls.ViewModels;
namespace BadgerClanControls
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }

}

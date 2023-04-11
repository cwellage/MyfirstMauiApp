using Microsoft.Maui.Controls.Xaml;
using System.Windows.Input;
using ViewModel;

namespace MyfirstMauiApp;
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    
    private void MyPageBtn_Clicked(object sender, EventArgs e)
    {
         Navigation.PushAsync(new MyPage());
    }
}


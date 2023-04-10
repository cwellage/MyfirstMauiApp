using Microsoft.Maui.Controls.Xaml;
using System.Windows.Input;
using ViewModel;

namespace MyfirstMauiApp;
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MainPage : ContentPage
{

    

    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }

    
    private void MyPageBtn_Clicked(object sender, EventArgs e)
    {
         Navigation.PushAsync(new MyPage());
    }
}


namespace MyfirstMauiApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
	}

    private void OnCounterClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage(new ViewModel.MainViewModel()));
        Shell.Current.FlyoutIsPresented = false;
    }

    private void OnCameraClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MyPage());
        Shell.Current.FlyoutIsPresented = false;
    }
}

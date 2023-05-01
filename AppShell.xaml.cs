namespace MyfirstMauiApp;

public partial class AppShell : Shell
{
    public MainPage _MainPage { get; set; }
    public AppShell(MainPage mainpage)
	{
		InitializeComponent();
        _MainPage = mainpage;

    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        Navigation.PopToRootAsync(true);// homepage
        Shell.Current.FlyoutIsPresented = false;
    }

    private void OnCameraClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MyPage());
        Shell.Current.FlyoutIsPresented = false;
    }
}

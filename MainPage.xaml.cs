namespace MyfirstMauiApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count%2 == 1)
		{ 
			CounterBtn.Text = $"Clicked {count} times";
			CounterBtn.BackgroundColor = Colors.Maroon;
		}
			
		else
		{
            CounterBtn.Text = $"Clicked {count} times";
            CounterBtn.BackgroundColor = Colors.GreenYellow;
        }
			

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

    private void MyPageBtn_Clicked(object sender, EventArgs e)
    {
		MyPage myPage = new MyPage();
		//myPage.LoadFromXaml(MyPageBtn.Text);
    }
}


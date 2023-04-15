using Microsoft.Maui.Media;

namespace MyfirstMauiApp;

public partial class MyPage : ContentPage
{
	public MyPage()
	{
		InitializeComponent();
	}

    public ImageSource ImageSource { get; set; }
    public Stream SourceStream { get; set; }


    private async void imageBtn_Clicked(object sender, EventArgs e)
    {
        var issupported =MediaPicker.Default.IsCaptureSupported;
     FileResult  photo = await MediaPicker.Default.CapturePhotoAsync();
        if (photo != null)
        {          
            Stream stream =  await photo.OpenReadAsync().ConfigureAwait(false);          
            SourceStream = stream;        
            myimage.Source = ImageSource.FromStream(() => SourceStream);
        }
    }
}
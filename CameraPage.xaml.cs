using Microsoft.Maui.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Http.Json;
using System.Security.Authentication;
using System.Text.Json;

namespace MyfirstMauiApp;

public partial class MyPage : ContentPage
{
	public MyPage()
	{
		InitializeComponent();
        this.BindingContext = this;
    }

    public ImageSource ImageSource { get; set; }
    public Stream SourceStream { get; set; }

    private string emotion;
    public string Emotion { 
        get => emotion; 
        set {
                emotion = value;
                OnPropertyChanged();
            }
    }


    private async void imageBtn_Clicked(object sender, EventArgs e)
    {
        var issupported =MediaPicker.Default.IsCaptureSupported;
     FileResult  photo = await MediaPicker.Default.CapturePhotoAsync();
        if (photo != null)
        {          
            Stream stream =  await photo.OpenReadAsync().ConfigureAwait(true); 
            SourceStream = stream;
            ImageSource = ImageSource.FromStream(() => SourceStream);
            myimage.Source = ImageSource;
            GetEmotion(SourceStream);
        }
    }

    public async void  GetEmotion(Stream sourceStream)
    {
        try
        {
            HttpClientHandler handler = new HttpClientHandler();
    
            HttpClient client = new HttpClient(handler);

            var memoryStream = new MemoryStream();
            sourceStream.CopyTo(memoryStream);
            byte[] byteArray = memoryStream.ToArray();

            // Create a new HttpRequestMessage with the necessary parameters

            var content = Convert.ToBase64String(byteArray);


            //var response =  client.Send(requestMessage);

            var response = await client.PostAsJsonAsync("https://127.0.0.1:44363/Emotion/FaceEmotion", content).ConfigureAwait(true);
            Emotion = await response.Content.ReadAsStringAsync();
        }
        catch (Exception e)
        {

            Emotion = e.Message;
        }
        

        
    }

}
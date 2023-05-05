using Microsoft.Maui.Media;
using System.Collections.Generic;
using System.ComponentModel;
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
            Stream stream =  await photo.OpenReadAsync().ConfigureAwait(false); 
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
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            HttpClient client = new HttpClient(handler);

            HttpRequestMessage requestMessage = new HttpRequestMessage();
            requestMessage.RequestUri = new Uri("https://10.0.2.2:7174/Emotion");
            requestMessage.Method = HttpMethod.Get;
            requestMessage.Options.TryAdd("stream", sourceStream);

            //var response =  client.Send(requestMessage);

            var response = await client.GetAsync("https://10.0.2.2:7174/Emotion/EmotionTemp").ConfigureAwait(true);
            var responseDeserialize = JsonSerializer.Deserialize<string>(response.ToString());
            Emotion = responseDeserialize;
        }
        catch (Exception e)
        {

            Emotion = e.Message;
        }
        

        
    }

}
using System.Windows.Input;

namespace ViewModel
{
    // All the code in this file is included in all platforms.
    public class MainViewModel : BindableObject
    {
        public MainViewModel()
        {

            this.BindingContext = this;
            DisplayCount = new Command(OnIncrease);
        }

        int count = 0;
        string countDisplay = "click me";
        Color countBtnColor = Colors.Blue;

        public string CountDisplay
        {
            get
            {
                return countDisplay;

            }
            set
            {

                if (value == countDisplay)
                    return;

                countDisplay = value;
                OnPropertyChanged();
            }
        }
        public Color CountBtnColor
        {
            get => countBtnColor;
            set
            {
                countBtnColor = value;
                OnPropertyChanged();
            }
        }

        public ICommand DisplayCount { get; }

        public void OnIncrease()
        {
            count++;
            CountDisplay = $"Clicked {count} times";

            if (count % 2 == 1)
            {
                CountBtnColor = Colors.Maroon;
            }

            else
            {
                CountBtnColor = Colors.GreenYellow;
            }
        }
    }
}
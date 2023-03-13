namespace VictorFrye.Coldfire.App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCheckoutSourceClicked(object sender, EventArgs e)
        {
            await Launcher.Default.OpenAsync("https://github.com/victorfrye/coldfire");
        }
    }
}
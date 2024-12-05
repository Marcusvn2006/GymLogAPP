using Microsoft.Maui.Controls;

namespace DevQuiz
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnIniciarTapped(object sender, EventArgs e)
        {
            // Navega para a página de Login
            await Navigation.PushAsync(new DevQuiz.Pages.Login());
        }

        private async void OnRegistrarTapped(object sender, EventArgs e)
        {
            // Navega para a página de Registro
            await Navigation.PushAsync(new DevQuiz.Pages.Registro()); 
        }
    }
}

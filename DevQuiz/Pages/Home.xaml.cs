using DevQuiz.Pages;
using Microsoft.Maui.Controls;

namespace DevQuiz.Pages
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        // Método chamado ao clicar no botão "Treinos"
        private async void OnTreinosTapped(object sender, EventArgs e)
        {
           
            await Navigation.PushAsync(new Treinos()); 
        }
    }
}

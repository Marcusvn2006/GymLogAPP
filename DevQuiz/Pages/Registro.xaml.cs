using Microsoft.Maui.Controls;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DevQuiz.Pages
{
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            // Obtém os valores dos campos
            string email = emailEntry.Text;
            string senha = passwordEntry.Text;

            // Verifica se todos os campos foram preenchidos
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                resultLabel.Text = "Todos os campos são obrigatórios.";
                resultLabel.IsVisible = true;
                return;
            }

            // Envia os dados para a API
            var sucesso = await RegistrarUsuario(email, senha);

            if (sucesso)
            {
                await DisplayAlert("Sucesso", "Usuário registrado com sucesso!", "OK");

                // Navega para a tela de Login após o registro com sucesso
                await Navigation.PushAsync(new Login());  // Aqui você substitui "Login" pela classe da sua tela de login
            }
            else
            {
                resultLabel.Text = "Erro ao tentar registrar. Tente novamente.";
                resultLabel.IsVisible = true;
            }
        }

        private async Task<bool> RegistrarUsuario(string email, string senha)
        {
            try
            {
                // URL da API
                string url = "https://api-gym-log.somee.com/identity/register";

                // Cria o cliente HTTP
                using (var client = new HttpClient())
                {
                    // Cria o objeto com os dados para enviar na requisição
                    var dados = new
                    {
                        email = email,
                        password = senha
                    };

                    // Converte o objeto para JSON
                    string json = JsonConvert.SerializeObject(dados);

                    // Cria o conteúdo da requisição
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Envia a requisição POST
                    var response = await client.PostAsync(url, content);

                    // Verifica se a resposta foi bem-sucedida
                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                // Se ocorrer uma exceção, retorna falso
                Console.WriteLine($"Erro ao tentar registrar: {ex.Message}");
                return false;
            }
        }
    }
}

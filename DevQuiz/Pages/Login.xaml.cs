using Newtonsoft.Json;  // Certifique-se de que o Newtonsoft.Json está instalado
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace DevQuiz.Pages;

public partial class Login : ContentPage
{
    private readonly HttpClient _httpClient;

    public Login()
    {
        InitializeComponent();
        _httpClient = new HttpClient();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string email = emailEntry.Text;
        string password = passwordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            resultLabel.Text = "Por favor, preencha todos os campos.";
            resultLabel.IsVisible = true;
            return;
        }

        var loginRequest = new
        {
            Email = email,
            Password = password
        };

        try
        {
            // Define a URL completa da API de login
            string url = "https://api-gym-log.somee.com/identity/login";

            // Serializa o objeto para JSON
            var jsonContent = JsonConvert.SerializeObject(loginRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            // Envia a requisição POST
            var response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                resultLabel.TextColor = Colors.Green;
                resultLabel.Text = "Login realizado com sucesso!";
                resultLabel.IsVisible = true;

                // Redireciona para a página Home, caso o login seja bem-sucedido
                await Navigation.PushAsync(new Home());
            }
            else
            {
                resultLabel.TextColor = Colors.Red;
                resultLabel.Text = "Falha no login. Verifique suas credenciais.";
                resultLabel.IsVisible = true;
            }
        }
        catch (Exception ex)
        {
            resultLabel.TextColor = Colors.Red;
            resultLabel.Text = $"Erro: {ex.Message}";
            resultLabel.IsVisible = true;
        }
    }
}

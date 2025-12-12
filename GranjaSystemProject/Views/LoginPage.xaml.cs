using GranjaSystemProject.Helpers;
using GranjaSystemProject.Services;

namespace GranjaSystemProject.Views;
public partial class LoginPage : ContentPage
{
    private readonly AuthService _authservice;

    public LoginPage()
    {
        InitializeComponent();
        _authservice = ServiceProviderHelper.GetService<AuthService>();
    }
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text?.Trim();
        string password = PasswordEntry.Text?.Trim();

        var user = await _authservice.AuthenticateUser(email, password);

        if (user is null)
        {
            await DisplayAlert("Erro", "Email ou senha incorretos.", "OK");
            return;
        }

        string token = _authservice.GenerateJwtToken(user);

        await SecureStorage.SetAsync("jwt_token", token);
        await Navigation.PushAsync(new HomePage());
    }
}

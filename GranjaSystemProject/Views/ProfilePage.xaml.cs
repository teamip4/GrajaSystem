using GranjaSystemProject.Helpers;
using GranjaSystemProject.Services;

namespace GranjaSystemProject.Views;

public partial class ProfilePage : ContentPage
{
	private readonly AuthService _authservice;
	public ProfilePage()
	{
		InitializeComponent();

        _authservice = ServiceProviderHelper.GetService<AuthService>();

        Reload();
	}

    public void Reload()
    {
        var user = _authservice.CurrentUser;

        LabelName.Text = user.Name;
        LabelBirthDate.Text = user.BirthDate.ToString("dd/mm/yyyy");
        LabelEmail.Text = user.Email;
        LabelCpf.Text = user.Cpf;
        LabelState.Text = user.State;
        LabelCity.Text = user.City;
        LabelAddress.Text = user.Address;
        LabelPhone.Text = user.Phone;
    }
}

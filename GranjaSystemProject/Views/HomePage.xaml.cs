namespace GranjaSystemProject.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}
	public async void OnProfileClicked(Object sender, EventArgs e)
	{
        await Navigation.PushAsync(new ProfilePage());
    }
}
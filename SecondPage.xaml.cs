
namespace Proyecto2_MZ_MJ;

public partial class SecondPage : ContentPage
{
	public SecondPage()
	{
		InitializeComponent();
	}
    private void OnOpenPageClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SecondPage());
    }
    private void OnOpenPageClicked_Foro2(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Conpartida());

    }
}
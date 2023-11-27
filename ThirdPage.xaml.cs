
namespace Proyecto2_MZ_MJ;

public partial class ThirdPage : ContentPage
{
	public ThirdPage()
	{
		InitializeComponent();
	}
    private void OnOpenPageClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ThirdPage());
    }
    private void OnOpenPageClicked_Foro3(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Familiar());

    }
}
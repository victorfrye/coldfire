using VictorFrye.Coldfire.Data.Characters;

namespace VictorFrye.Coldfire.App.Characters;

public partial class CharactersPage : ContentPage
{
	public CharactersPage(CharacterViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
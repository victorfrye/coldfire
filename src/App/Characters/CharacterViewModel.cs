using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using VictorFrye.Coldfire.Data.Characters;

namespace VictorFrye.Coldfire.App.Characters
{
    public class CharacterViewModel : ViewModel
    {
        private int id;
        private Character character;
        private ImageSource profile;
        private string displayName;

        private readonly IRestService<Character> _restService;
        private readonly IUserDialogService _userDialogService;

        public ICommand FindCharacterCommand { get; private set; }

        public int Id
        {
            get { return id; }
            set
            {
               if (id != value)
                {
                    id = value;
                    switch (character)
                    {
                        case null:
                            Character = new Character(value);
                            break;
                        default:
                            character.Id = value;
                            OnPropertyChanged(nameof(Character));
                            break;
                    }

                    OnPropertyChanged();
                }
            }
        }

        public Character Character
        {
            get { return character; }
            set
            {
                if (character != value)
                {
                    character = value;
                    id = value.Id;

                    SetProfileImage();
                    SetDisplayName();

                    OnPropertyChanged(nameof(Id));
                    OnPropertyChanged();
                }
            }
        }

        public ImageSource Profile
        {
            get { return profile; }
            set
            {
                if (profile != value)
                {
                    profile = value;
                    OnPropertyChanged();
                }
            }
        }

        public string DisplayName
        {
            get { return displayName; }
            set
            {
                if (displayName != value)
                {
                    displayName = value;
                    OnPropertyChanged();
                }
            }
        }

        public CharacterViewModel(IRestService<Character> restService, IUserDialogService userDialogService) 
        {
            _restService = restService;
            _userDialogService = userDialogService;
            FindCharacterCommand = new Command(FindCharacter);
            profile = ImageSource.FromFile("person_with_crown_3d_default.png");
        }

        private async void FindCharacter() {
            var result = await _restService.SendGet(id);

            if (result == null)
            {
                await _userDialogService.DisplayAlert("Not Found", $"No character was found with ID of {id}.", "OK");
                Character = new Character(id);
                return;
            }

            Character = result;
        }

        private void SetProfileImage()
        {
            if (character == null || character.Gender == null) { return; }

            switch (character.Gender.ToUpper())
            {
                case "MALE":
                    Profile = ImageSource.FromFile("prince_3d_default.png");
                    OnPropertyChanged(nameof(Profile));
                    break;
                case "FEMALE":
                    Profile = ImageSource.FromFile("princess_3d_default.png");
                    OnPropertyChanged(nameof(Profile));
                    break;
                default:
                    Profile = ImageSource.FromFile("person_with_crown_3d_default.png");
                    OnPropertyChanged(nameof(Profile));
                    break;
            }
        }

        private void SetDisplayName()
        {
            DisplayName = string.IsNullOrWhiteSpace(character.Name) ? character.Aliases.FirstOrDefault() : character.Name;
        }
    }
}

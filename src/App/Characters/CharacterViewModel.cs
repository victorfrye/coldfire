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

        private readonly IService<Character> _service;

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
                            character = new Character(value);
                            break;
                        default:
                            character.Id = value;
                            break;
                    }

                    SetProfileImage();

                    OnPropertyChanged(nameof(Character));
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

        public CharacterViewModel(IService<Character> service) 
        {
            _service = service;
            FindCharacterCommand = new Command(FindCharacter);
            profile = ImageSource.FromFile("person_with_crown_3d_default.png");
        }

        private void FindCharacter()
        {
            Character = _service.Find(id);
        }

        private void SetProfileImage()
        {
            if (character == null) { return; }

            switch (character.Gender)
            {
                case "Male":
                    profile = ImageSource.FromFile("prince_3d_default.png");
                    OnPropertyChanged(nameof(Profile));
                    break;
                case "Female":
                    profile = ImageSource.FromFile("princess_3d_default.png");
                    OnPropertyChanged(nameof(Profile));
                    break;
                default:
                    profile = ImageSource.FromFile("person_with_crown_3d_default.png");
                    OnPropertyChanged(nameof(Profile));
                    break;
            }
        }
    }
}

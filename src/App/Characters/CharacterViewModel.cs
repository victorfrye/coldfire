using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using VictorFrye.Coldfire.Data.Characters;

namespace VictorFrye.Coldfire.App.Characters
{
    public class CharacterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Character character;

        private readonly IService<Character> _service;

        public ICommand FindCharacterCommand { get; private set; }

        public Character Character
        {
            get { return character; }
            set
            {
                if (character != value)
                {
                    character = value;
                    OnPropertyChanged();
                }
            }
        }

        public CharacterViewModel(IService<Character> service) 
        {
            _service = service;
            FindCharacterCommand = new Command<int>((id) => FindCharacter(id));
        }

        private void FindCharacter(int id)
        {
            Character = _service.Find(id);
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

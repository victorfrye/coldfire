using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VictorFrye.Coldfire.Data.Characters;

namespace VictorFrye.Coldfire.App
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

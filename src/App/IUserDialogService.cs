using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorFrye.Coldfire.App
{
    public interface IUserDialogService
    {
        Task<bool> DisplayAlert(string title, string message, string accept, string cancel, FlowDirection flowDirection);

        Task<bool> DisplayAlert(string title, string message, string accept, string cancel);

        Task DisplayAlert(string title, string message, string cancel);

        Task DisplayAlert(string title, string message, string cancel, FlowDirection flowDirection);
    }
}

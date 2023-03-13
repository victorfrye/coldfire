using Microsoft.Maui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorFrye.Coldfire.App
{
    public class UserDialogService : IUserDialogService
    {
        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel, FlowDirection flowDirection)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel, flowDirection);
        }

        public async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }

        public Task DisplayAlert(string title, string message, string cancel)
        {
            return Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public Task DisplayAlert(string title, string message, string cancel, FlowDirection flowDirection)
        {
            return Application.Current.MainPage.DisplayAlert(title, message, cancel, flowDirection);
        }
    }
}

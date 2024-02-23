using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using SimFit360.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SimFit360_
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        internal async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            //Put input in variable.
            string name = Name.Text;
            string inputPassword = Password.Password;

            using (var db = new AppDbContext())
            {
                var user = db.Users.FirstOrDefault(e => e.Name == name);
                //Check if password is correct. 
                if (user != null && VerifyPassword(inputPassword, user.Password, name))
                {
                    User.LoggedInUser = user;
                    Name.Text = "";
                    Password.Password = "";
                    Frame.Navigate(typeof(DashboardPage));
                }
                else
                {
                    //Removes input from input boxes.
                    Name.Text = null;
                    Password.Password = null;

                    //Error message
                    ContentDialog wrongCredentialsDialog = new ContentDialog
                    {
                        Title = "Login Failed",
                        Content = "Please check your credentials.",
                        CloseButtonText = "Ok",
                        XamlRoot = this.XamlRoot,
                    };

                    ContentDialogResult result = await wrongCredentialsDialog.ShowAsync();
                }
            }
        }
        private bool VerifyPassword(string inputPassword, string hashedPassword, string email)
        {
            return SecureHasher.Verify(inputPassword, hashedPassword);
        }
        private void loginButton_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            // loginButton.Background = new SolidColorBrush(Colors.Gold);
        }
    }
}

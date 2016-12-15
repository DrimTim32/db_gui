using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace GuiBase
{
    public partial class LoginForm
    {
        private readonly Action<UserTypes> _callbackFunc;

        public LoginForm(Action<UserTypes> callback)
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            _callbackFunc = callback;
        }


        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string password = PasswordBox.Password;
            if (login.Equals("admin") && password.Equals("admin"))
            {
                _callbackFunc(UserTypes.Admin);
                Close();
            }
            else if(login.Equals("kelner"))
            { 
                _callbackFunc(UserTypes.Waitress);
                Close();
            }
        }
    }
}

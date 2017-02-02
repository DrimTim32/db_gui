using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BarApplication.ViewModels
{
    using System.ComponentModel;
    using DataProxy;
    using DataProxy.Entities;
    using FirstFloor.ModernUI.Presentation;

    public class UserViewModel
        : NotifyPropertyChanged, IDataErrorInfo
    {
        private string name;
        private string surname;
        private string login;
        private string password;
        private UserPrivileges? permission = null;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string Permission
        {
            get { return permission.HasValue ? permission.Value.ToReadable() : null; }
            set { permission = UserPrivlidgesExtensions.GetValueFromDescription(value); }
        }
        public string Error
        {
            get { return null; }
        }
        public string this[string columnName]
        {
            get
            {
                if (columnName == "Name")
                {
                    return string.IsNullOrEmpty(Name) ? "Required value" : null;
                }
                if (columnName == "Surname")
                {
                    return string.IsNullOrEmpty(Surname) ? "Required value" : null;
                }
                if (columnName == "Permission")
                {
                    return !permission.HasValue ? "Required value" : null;
                }
                if (columnName == "Login")
                {
                    return string.IsNullOrEmpty(this.Login) ? "Required value" : null;
                }
                return null;
            }
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.BarApplication.Content.Users
{
    /// <summary>
    /// Interaction logic for Waiter.xaml
    /// </summary>
    public partial class Waiter : UserControl
    {
        public Waiter()
        {
            InitializeComponent();
            this.Loaded += (s, e) => { Except(); };
        }

        public void Except()
        {
            throw new Exception("asdf");
        }
         
    }
}

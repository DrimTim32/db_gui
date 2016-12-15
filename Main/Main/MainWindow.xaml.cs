using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitButtons();
        }

        public void InitButtons()
        {  
            var dict = new Dictionary<string, Action>
            { 
                {"Users", () => { }},
                {"Bar", () => { }},
                {"Warehouse", () => { }},
            };
            foreach (var key in dict.Keys)
            {
                //Buttons.Children.Add(GetButton(key, dict[key]));
            } 
        }
         
        public Button GetButton(string content, Action action)
        {
            var btn =  new Button {Content = content};
            btn.Click += (s, e) => { action(); };
            return btn;

        }
    }
}

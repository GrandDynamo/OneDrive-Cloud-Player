﻿using OneDrive_Cloud_Player.Login;
using Microsoft.Identity.Client.Extensibility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
//using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Graph;
using System.Net.Http.Headers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OneDrive_Cloud_Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void MenuItemSignIn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

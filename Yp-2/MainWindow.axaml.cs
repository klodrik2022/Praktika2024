using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;
using System;
using Avalonia.Media;
using Avalonia.Controls;
using System.IO;
using System.Windows;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Utilities;
using System;
using System.Globalization;
using Avalonia.Platform;

namespace Yp_2;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    string connectionString = "server=localhost;database=up;port=3306;User Id=root;password=05042005";
    
    public void Authorization(object? sender, RoutedEventArgs e)
    {
        if (Login.Text == "admin" && Password.Text == "admin")
        {
            Servic employee = new Servic();
            employee.AddButton.IsVisible = true;
            employee.EditButton.IsVisible = true;
            employee.DeleteButton.IsVisible = true;
            employee.Rec.IsVisible = false;
            employee.Title = "Режим администратора";
            this.Hide();
            employee.Show();
            
        }
        else 
        {
            Servic client = new Servic();
            client.AddButton.IsVisible = false;
            client.EditButton.IsVisible = false;
            client.DeleteButton.IsVisible = false;
            this.Hide();
            client.Show();
        }
    }
    public void Exit_Program(object? sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }
}
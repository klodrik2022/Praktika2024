using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;
using System;
using System.Windows;


namespace Yp_2;

public partial class AddEditForm : Window
{
    private List<Service> _Services;
    private Service CurrentServ;

    public AddEditForm(Service currentServ, List<Service> _services)
    {
        InitializeComponent();
        CurrentServ = currentServ;
        this.DataContext = currentServ;
        _Services = _services;
       
    }

    private MySqlConnection conn;
    string connStr = "server=localhost;database=up;port=3306;User Id=root;password=05042005";

    private void Save_OnClick(object? sender, RoutedEventArgs e)
    {
        var usr = _Services.FirstOrDefault(x => x.ID == CurrentServ.ID);
        if (usr == null)
        {
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                string add =
                    "INSERT INTO service (name, discount,  time, price, photo) VALUES ('" +
                    Name.Text + "', '" + Convert.ToDouble(Discount.Text) + "', '" + Time.Text + "', '" + Price.Text + "', '" +
                    Img.Text + "');";
                MySqlCommand cmd = new MySqlCommand(add, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                Servic back = new Servic();
                this.Close();
                back.Show();
                back.Rec.IsVisible = false;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error" + exception);
            }
        }
        else
        {
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                string upd = "UPDATE service SET name = '" + Name.Text +
                             "', Discount = '" + Convert.ToInt32(Discount.Text) + "', Time = '" +
                             Time.Text + 
                             "', Price = '" + Price.Text +  "', Photo = '" +
                             Img.Text + "' WHERE ID = " + Convert.ToInt32(ID.Text) + ";";
                MySqlCommand cmd = new MySqlCommand(upd, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                
                Servic back = new Servic();
                this.Close();
                back.Show();
                back.Rec.IsVisible = false;
            }
            catch (Exception exception)
            {
                Console.Write("Error" + exception);
            }
        }
    }

    private void GoBack(object? sender, RoutedEventArgs e)
    {
        Servic back = new Servic();
        this.Close();
        back.Show();
        back.Rec.IsVisible = false;
    }

    private async void File_Select(object sender, RoutedEventArgs e)
    {
        try
        {
            OpenFileDialog fileDialog = new OpenFileDialog(); //создание диалогового окна выбора файла
            fileDialog.Filters.Add(new FileDialogFilter() { Name = "Image Files", Extensions = { "jpg", "jpeg", "png", "gif" } }); //ограничение на выбор только изображений
            string[]? fileNames = await fileDialog.ShowAsync(this); //отображение диалогового окна и получение выбранных файлов
            if (fileNames != null && fileNames.Length > 0) //если файл выбран
            {
                string imagePath = System.IO.Path.GetFileName(fileNames[0]); //получение пути к выбранному файлу
                Img.Text = imagePath;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
}
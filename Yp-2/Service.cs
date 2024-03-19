using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Windows;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Utilities;
using System;
using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
namespace Yp_2;

public class Service
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Discount { get; set; }
    public string Time { get; set; }
    public int Price { get; set; }
    public int price_discount { get; set; }
    public Bitmap? Photo { get; set; }
    public string Изображение_услуги_путь { get; set; }
}

public class Record
{
    public int id { get; set; }
    public int Client { get; set; }
    public int Employee { get; set; }
    public int Service { get; set; }
    public int Date { get; set; }
}

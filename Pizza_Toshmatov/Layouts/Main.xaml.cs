using System;
using System.Collections.Generic;
using System.IO;
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

namespace Pizza_Toshmatov.Layouts
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main(MainWindow mainWindow)
        {
            InitializeComponent();

        }

        /// <summary>
        /// Функция создания пиццы
        /// </summary>


        public List<Dish> dishs = new List<Dish>();


        public void CreatePizza(MainWindow mainWindow, List<Dish> dishs)
        {

            for (int i = 0; i < dishs.Count; i++)
            {
                var bc = new BrushConverter(); 
                Grid global = new Grid(); 
                global.Height = 100; 
                global.Background = (Brush)bc.ConvertFrom("#FFECECEC"); 
                if (i > 0) global.Margin = new Thickness(0, 10, 0, 0); 

                Image logo = new Image();
                if (File.Exists(mainWindow.localPath + @"C:\Users\student-a502.PERMAVIAT\source\repos\Pizza_Toshmatov\Pizza_Toshmatov\Layouts\img-6.png" + dishs[i].img + ".png"))
                    logo.Source = new BitmapImage(new Uri(mainWindow.localPath + @"\image\dish\" + dishs[i].img + ".png"));
                    logo.Source = new BitmapImage(new Uri(mainWindow.localPath + @"C:\Users\student-a502.PERMAVIAT\source\repos\Pizza_Toshmatov\Pizza_Toshmatov\Layouts\img-5.png"));

                logo.HorizontalAlignment = System.Windows.HorizontalAlignment.Left; 
                logo.Height = 50;
                logo.Margin = new Thickness(10, 10, 0, -10); 
                logo.VerticalAlignment = System.Windows.VerticalAlignment.Top; 
                logo.Width = 50; 

                global.Children.Add(logo); 

                Label name = new Label(); 
                name.Content = dishs[i].name; 
                name.HorizontalAlignment = System.Windows.HorizontalAlignment.Left; 
                name.VerticalAlignment = System.Windows.VerticalAlignment.Top; 
                name.Margin = new Thickness(65, 0, 0, 0); 
                name.FontWeight = FontWeights.Bold;

                global.Children.Add(name);

                Label description = new Label(); 
                description.Content = dishs[i].description;
                description.HorizontalAlignment = System.Windows.HorizontalAlignment.Left; 
                description.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                description.Margin = new Thickness(65, 20, 0, 0); 

                global.Children.Add(description); 

                if (dishs[i].ingredients.Count != 0) 
                {
                    Label ingredient = new Label();
                    string str_ingredient = ""; 

                    for (int j = 0; j < dishs[i].ingredients.Count; j++) 
                    {
                        str_ingredient += dishs[i].ingredients[j].name;
                        if (j != dishs[i].ingredients.Count - 1)
                        {
                            str_ingredient += ", "; 
                        }
                    }

                    ingredient.Content = "Состав: " + str_ingredient; 
                    ingredient.HorizontalAlignment = System.Windows.HorizontalAlignment.Left; 
                    ingredient.VerticalAlignment = System.Windows.VerticalAlignment.Top; 
                    ingredient.Margin = new Thickness(65, 40, 0, 0); 
                    global.Children.Add(ingredient); 
                }

                Label price = new Label(); // создаём текст
                price.Content = "Цена: " + dishs[i].sizes[0].price + " р.";
                price.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                price.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                price.Margin = new Thickness(65, 0, 0, 10); 

                global.Children.Add(price); 

                Label wes = new Label(); 
                wes.Content = "Вес: " + dishs[i].sizes[0].wes + " гр."; 
                wes.HorizontalAlignment = System.Windows.HorizontalAlignment.Left; 
                wes.VerticalAlignment = System.Windows.VerticalAlignment.Bottom; 
                wes.Margin = new Thickness(236, 0, 0, 10);

                global.Children.Add(wes); 

                Button button1 = new Button(); 
                Button button2 = new Button(); 
                Button button3 = new Button();

                Button minus = new Button(); 
                TextBox count = new TextBox(); 
                Button plus = new Button(); 
                CheckBox order = new CheckBox(); 

                button1.Content = dishs[i].sizes[0].size + " см.";
                button1.HorizontalAlignment = System.Windows.HorizontalAlignment.Right; 
                button1.VerticalAlignment = System.Windows.VerticalAlignment.Top; 
                button1.Margin = new Thickness(0, 10, 109.6, 0);
                button1.Width = 45; 
                button1.Background = Brushes.White; 
                button1.Foreground = (Brush)bc.ConvertFrom("#FFDD3333"); 
                button1.Tag = i; 

                button1.Click += delegate 
                {
                    price.Content = "Цена: " + dishs[int.Parse(button1.Tag.ToString())].sizes[0].price + " р."; 
                    wes.Content = "Вес: " + dishs[int.Parse(button1.Tag.ToString())].sizes[0].wes + " гр.";
                    button1.Background = Brushes.White; 
                    button1.Foreground = (Brush)bc.ConvertFrom("#FFDD3333");

                    button2.Background = (Brush)bc.ConvertFrom("#FFDD3333"); 
                    button2.Foreground = Brushes.White; 
                    button3.Background = (Brush)bc.ConvertFrom("#FFDD3333");
                    button3.Foreground = Brushes.White; 

                    dishs[int.Parse(button1.Tag.ToString())].activeSize = 0;
                    count.Text = dishs[int.Parse(button1.Tag.ToString())].sizes[0].countOrder.ToString(); 
                    order.IsChecked = dishs[int.Parse(button1.Tag.ToString())].sizes[0].orders; 
                };

                global.Children.Add(button1); 

                button2.Content = dishs[i].sizes[1].size + " см."; 
                button2.HorizontalAlignment = System.Windows.HorizontalAlignment.Right; 
                button2.VerticalAlignment = System.Windows.VerticalAlignment.Top; 
                button2.Margin = new Thickness(0, 10, 59.6, 0); 
                button2.Width = 45; 
                button2.Tag = i; 

                button2.Click += delegate 
                {
                    price.Content = "Цена: " + dishs[int.Parse(button2.Tag.ToString())].sizes[1].price + " р."; 
                    wes.Content = "Вес: " + dishs[int.Parse(button2.Tag.ToString())].sizes[1].wes + " гр."; 

                    button2.Background = Brushes.White;
                    button2.Foreground = (Brush)bc.ConvertFrom("#FFDD3333"); 

                    button1.Background = (Brush)bc.ConvertFrom("#FFDD3333"); 
                    button1.Foreground = Brushes.White;
                    button3.Background = (Brush)bc.ConvertFrom("#FFDD3333"); 
                    button3.Foreground = Brushes.White; 

                    dishs[int.Parse(button1.Tag.ToString())].activeSize = 1;
                    count.Text = dishs[int.Parse(button1.Tag.ToString())].sizes[1].countOrder.ToString(); 
                    order.IsChecked = dishs[int.Parse(button1.Tag.ToString())].sizes[1].orders; 
                };

                global.Children.Add(button2); 

                button3.Content = dishs[i].sizes[2].size + " см."; 
                button3.HorizontalAlignment = System.Windows.HorizontalAlignment.Right; 
                button3.VerticalAlignment = System.Windows.VerticalAlignment.Top; 
                button3.Margin = new Thickness(0, 10, 9.6, 0);
                button3.Width = 45; 
                button3.Tag = i; 

                button3.Click += delegate
                {
                    price.Content = "Цена: " + dishs[int.Parse(button3.Tag.ToString())].sizes[2].price + " р."; 
                    wes.Content = "Вес: " + dishs[int.Parse(button3.Tag.ToString())].sizes[2].wes + " гр.";
                    button3.Background = Brushes.White; 
                    button3.Foreground = (Brush)bc.ConvertFrom("#FFDD3333"); 

                    button1.Background = (Brush)bc.ConvertFrom("#FFDD3333");
                    button1.Foreground = Brushes.White; 
                    button2.Background = (Brush)bc.ConvertFrom("#FFDD3333"); 
                    button2.Foreground = Brushes.White;

                    dishs[int.Parse(button1.Tag.ToString())].activeSize = 2; 
                    count.Text = dishs[int.Parse(button1.Tag.ToString())].sizes[2].countOrder.ToString();
                    order.IsChecked = dishs[int.Parse(button1.Tag.ToString())].sizes[2].orders; 
                };

                global.Children.Add(button3); 

                minus.Content = "-";
                minus.HorizontalAlignment = System.Windows.HorizontalAlignment.Right; 
                minus.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                minus.Margin = new Thickness(0, 0, 103.6f, 10); 
                minus.Width = 19; 
                minus.Tag = i; 

                minus.Click += delegate 
                {
                    if (count.Text != "") 
                    {
                        if (int.Parse(count.Text) > 0) 
                        {
                            count.Text = (int.Parse(count.Text) - 1).ToString(); 
                            int id = int.Parse(minus.Tag.ToString()); 
                            dishs[id].sizes[dishs[id].activeSize].countOrder = int.Parse(count.Text); 
                        }
                    }
                };

                global.Children.Add(minus); 

                count.Text = "0";
                count.HorizontalAlignment = System.Windows.HorizontalAlignment.Right; 
                count.VerticalAlignment = System.Windows.VerticalAlignment.Bottom; 
                count.Margin = new Thickness(0, 0, 33.6f, 10);
                count.TextWrapping = TextWrapping.Wrap;
                count.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center; 
                count.Width = 65; 
                count.Height = 19;
                count.Tag = i; 

                global.Children.Add(count); 

                plus.Content = "+"; 
                plus.HorizontalAlignment = System.Windows.HorizontalAlignment.Right; 
                plus.VerticalAlignment = System.Windows.VerticalAlignment.Bottom; 
                plus.Margin = new Thickness(0, 0, 9.6f, 10); 
                plus.Width = 19; 
                plus.Tag = i;

                plus.Click += delegate 
                {
                    if (count.Text != "") 
                    {
                        if (int.Parse(count.Text) < 15) 
                        {
                            count.Text = (int.Parse(count.Text) + 1).ToString();
                            int id = int.Parse(plus.Tag.ToString()); 
                            dishs[id].sizes[dishs[id].activeSize].countOrder = int.Parse(count.Text); 
                        }
                    }
                };

                global.Children.Add(plus);

                order.Content = "Выбрать"; 
                order.HorizontalAlignment = System.Windows.HorizontalAlignment.Right; 
                order.VerticalAlignment = System.Windows.VerticalAlignment.Bottom; 
                order.Margin = new Thickness(0, 0, 128, 13); 
                order.Tag = i;

                order.Click += delegate 
                {
                    int id = int.Parse(order.Tag.ToString()); 
                    dishs[id].sizes[dishs[id].activeSize].orders = (bool)order.IsChecked; 
                };

                global.Children.Add(order); 

                parent.Children.Add(global);
            }
        }
    }
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfFinal
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        public Calculator()
        {
            InitializeComponent();

            //Используется для добавления чисел в TextBlock
            foreach (UIElement element in GroupButton.Children)
            {
                if (element is Button)
                {
                    ((Button)element).Click += ButtonClick;
                }
            }
        }
        
        private void ButtonClick(Object sender, RoutedEventArgs e)
        {
            // Проверка исключений
            try
            {
                //Присвоение знакам действий при нажатии кнопки 
                string textButton = ((Button)e.OriginalSource).Content.ToString();
                if (textButton == "C")
                {
                    text.Clear();
                }
                else if (textButton == "=")
                {
                    text.Text = new DataTable().Compute(text.Text, null).ToString();
                }
                else text.Text += textButton;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Метод для закрытия окна
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

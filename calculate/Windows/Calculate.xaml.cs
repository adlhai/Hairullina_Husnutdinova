using System;
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
using System.Windows.Shapes;
using calculate.Classes;
using calculate.Models;
using calculate.UserControls;

namespace calculate.Windows
{
    /// <summary>
    /// Логика взаимодействия для Calculate.xaml
    /// </summary>
    public partial class Calculate : Window
    {
        public Calculate()
        {
            InitializeComponent();
            LoadData();
            Classes.Class_ConstantData.connection.Open();
            Class_ConstantData.Calcul = this;
        }
        private readonly calculatorContext _dbContext = new calculatorContext();
        
        public void LoadData()
        {
            RoomsView.Children.Clear();
            List<Models.Room> list = App.context.Room.ToList();


            for (int i = 0; i < list.Count; i++)
            {
                var userControl = new UserControls.UserControl1(list[i].Id.ToString(), list[i].Nameroom, list[i].Descriptions, list[i].Persons, list[i].Cost.ToString(), list[i].Photo);

                RoomsView.Children.Add(userControl);

            }

        }

            private void Button_Cost_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Cost_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_Time_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Go_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

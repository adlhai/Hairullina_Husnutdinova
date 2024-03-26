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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;
using calculate.Models;

namespace calculate.UserControls
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public event Action<string> RoomCostSelected;
        public event Action<string> RoomIdSelected;
        public UserControl1(string Id, string Nameroom, string Descriptions, string Persons, string Cost, byte[] Photo)
        {
            InitializeComponent();
            this.RoomName.Text = Nameroom;
            this.RoomPeoples.Text += " " + Persons;
            this.RoomDescr.Text += " " + Descriptions;
            this.RoomCost.Text += " " + Cost;
            this.RoomId.Text = Id;


            try
            {
                MemoryStream Image_AsStream = new MemoryStream(Photo);
                BitmapImage Image_AsBM = new BitmapImage();
                Image_AsBM.BeginInit();
                Image_AsBM.StreamSource = Image_AsStream;
                Image_AsBM.EndInit();
                Image_Room.Source = Image_AsBM;
            }
            catch
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RoomCostSelected?.Invoke(this.RoomCost.Text);
            RoomIdSelected?.Invoke(this.RoomId.Text);
        }
    }
}

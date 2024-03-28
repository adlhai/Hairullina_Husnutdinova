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
            TextBox_Date1.DisplayDateStart = DateTime.Now;
            TextBox_Date2.DisplayDateStart = DateTime.Now;
            LoadData();
            Classes.Class_ConstantData.connection.Open();
            Class_ConstantData.Calcul = this;
        }
        private readonly calculatorContext _dbContext = new calculatorContext();
        string Roomcosts = null;
        decimal Roomcostsss;
        private void UserControl_RoomCostSelected(string cost)
        {

            string[] RC = cost.Split(' ');
            if (RC.Length >= 2)
            {
                Roomcosts = RC[RC.Length - 1];

            }

            if (decimal.TryParse(Roomcosts, out Roomcostsss))
            {
                // Преобразование успешно
            }


        }
        int RoomsId;
        private void UserControl_RoomIdSelected(string Id)
        {

            string RId = Id;
            if (int.TryParse(RId, out RoomsId))
            {
                // Преобразование успешно
            }

        }
        private int eventId;
        public void LoadData()
        {
            RoomsView.Children.Clear();
            List<Models.Room> list = App.context.Room.ToList();


            for (int i = 0; i < list.Count; i++)
            {
                var userControl = new UserControls.UserControl1(list[i].Id.ToString(), list[i].Nameroom, list[i].Descriptions, list[i].Persons, list[i].Cost.ToString(), list[i].Photo);
                userControl.RoomCostSelected += UserControl_RoomCostSelected;
                userControl.RoomIdSelected += UserControl_RoomIdSelected;
                RoomsView.Children.Add(userControl);

            }

            {
                var Ev = _dbContext.Event.ToList();
                ComboBox_event.ItemsSource = Ev;
                ComboBox_event.DisplayMemberPath = "Nameevent";

            }
            



            using (var context = new calculatorContext())
            {
                var categories = context.Services.OrderBy(c => c.Nameservices).ToList();
                foreach (var category in categories)
                {
                    var checkBox = new CheckBox
                    {
                        Content = category.Nameservices + " " + category.Cost + " руб.",
                        FontSize = 18,
                        Tag = category.Id
                    };

                    checkBoxPanel.Children.Add(checkBox);
                }
            }
            using (var contextF = new calculatorContext())
            {
                var Fur = contextF.Fershet.OrderBy(c => c.Namefershet).ToList();
                foreach (var Fur1 in Fur)
                {
                    var checkBox = new CheckBox
                    {
                        Content = Fur1.Namefershet + " " + Fur1.Descriptions + " " + Fur1.Cost + " руб.",
                        FontSize = 18,

                        Tag = Fur1.Id

                    };
                    TextBox textBox = new TextBox
                    {
                        FontSize = 14,
                        Width = 40,

                        Tag = Fur1.Id


                    };
                    textBox.PreviewTextInput += (sender, e) =>
                    {
                        if (!char.IsDigit(e.Text, e.Text.Length - 1))
                        {
                            e.Handled = true; // Отменяем ввод символа, если он не является цифрой
                        }
                    };
                    checkBoxPanelFursh.Children.Add(checkBox);

                    TextBoxPanelFursh.Children.Add(textBox);

                }
            }

        }
        int H = 0;
        int lastClientId;
        int lastHolidayId;
        
        private void Button_Cost_Click_1(object sender, RoutedEventArgs e)
        {
            if (TextBox_Date1.SelectedDate <= TextBox_Date2.SelectedDate)
            {
                if(TextBox_Date1.Text.Length != 0 && TextBox_Date2.Text.Length != 0)
                { 
            
                decimal CostFer = 0;

            decimal totalCost = 0;
                    {


                        foreach (UIElement element in checkBoxPanelFursh.Children)
                        {
                            if (element is CheckBox checkBox)
                            {

                                string[] parts = checkBox.Content.ToString().Split(' ');
                                if (decimal.TryParse(parts[parts.Length - 2], out decimal cost))
                                {

                                    var textBox = TextBoxPanelFursh.Children
                                        .OfType<TextBox>()
                                        .FirstOrDefault(tb => (int)tb.Tag == (int)checkBox.Tag);

                                    if (textBox != null && checkBox.IsChecked == true && decimal.TryParse(textBox.Text, out decimal quantity))
                                    {

                                        CostFer += cost * quantity;
                                    }
                                }
                            }

                        }
                        foreach (UIElement element in checkBoxPanel.Children)
                        {

                            if (element is CheckBox checkBox && checkBox.IsChecked == true) // Проверка, что элемент является чекбоксом и он выбран
                            {
                                string content = checkBox.Content.ToString(); // Получаем содержимое чекбокса
                                string[] parts = content.Split(' '); // Разделяем содержимое на части

                                // Попытка преобразовать предпоследнюю часть в число (стоимость)
                                if (parts.Length > 2 && decimal.TryParse(parts[parts.Length - 2], out decimal cost))
                                {
                                    totalCost += cost; // Добавляем стоимость к общей сумме
                                }
                            }
                        }
                        DateTime date1 = TextBox_Date1.SelectedDate ?? DateTime.MinValue;


                        DateTime date2 = TextBox_Date2.SelectedDate ?? DateTime.MinValue;

                        // Вычитание дат и получение разницы в часах
                        TimeSpan difference = date2 - date1;
                        double hoursDifference = difference.TotalHours;
                        decimal hoursDifferenceDecimal = (decimal)hoursDifference;
                        // Вывод количества часов
                        if (hoursDifferenceDecimal != 0)
                        {
                            decimal CostAtMerop = CostFer + totalCost + Roomcostsss * hoursDifferenceDecimal;
                            MessageBox.Show($"Итоговая стоимость: {CostAtMerop}");

                        }
                        else if (TextBox_Date2.Text == TextBox_Date1.Text && TextBox_Time.Text != null)
                        {
                            string HourText = TextBox_Time.Text;

                            if (int.TryParse(HourText, out H))
                            {
                                // Преобразование успешно
                            }
                            decimal CostAtMerop = CostFer + totalCost + Roomcostsss * H;
                            MessageBox.Show($"Итоговая стоимость: {CostAtMerop}");

                        }
                    }

            }
                else
                {
                    MessageBox.Show("Введите дату мероприятия");
                }
            }
            else
            {
                MessageBox.Show("Дата завершения мероприятия не может быть раньше, чем его начало");
            }
        }


        private void TextBox_Time_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox_Time.Clear();
        }

        private void Button_Go_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_Date1.SelectedDate <= TextBox_Date2.SelectedDate)
            {
                if (TextBox_Name.Text.Length != 0 && TextBox_Phone.Text.Length != 0 && TextBox_Mail.Text.Length != 0)
                {
                    Klient newClient = new Klient
                    {
                        Fullname = TextBox_Name.Text,
                        Phone = TextBox_Phone.Text,
                        Email = TextBox_Mail.Text
                    };
                    _dbContext.Klient.Add(newClient);
                    _dbContext.SaveChanges();
                    lastClientId = newClient.Id;

                    string HourText = TextBox_Time.Text;

                    if (int.TryParse(HourText, out H))
                    {
                        // Преобразование успешно
                    }
                    if (ComboBox_event.SelectedItem != null)
                    {

                        var selectedEvent = (Event)ComboBox_event.SelectedItem;// Получаем выбранный элемент из комбобокса


                        eventId = selectedEvent.Id;// Присваиваем переменной eventId Id выбранного элемента
                    }

                    if (TextBox_Date1.Text.Length != 0 && TextBox_Date2.Text.Length != 0 && eventId != 0 && lastClientId != 0)
                    {
                        Holiday newHoliday = new Holiday
                        {

                            Startdate = TextBox_Date1.SelectedDate ?? DateTime.Now,
                            Enddate = TextBox_Date2.SelectedDate ?? DateTime.Now,
                            Eventid = eventId,
                            Roomid = RoomsId,
                            Klientid = lastClientId,
                            Hours = H,

                        };
                        _dbContext.Holiday.Add(newHoliday);
                        _dbContext.SaveChanges();
                        lastHolidayId = newHoliday.Id;
                        MessageBox.Show("Ваша заявка принята, ожидайте звонок администратора в теч. 24 часов");
                    }
                    else
                    {
                        MessageBox.Show("Убедитесь, что вы выбрали даты мероприятий и помещение!");
                    }





                    using (var context = new calculatorContext())
                    {
                        List<TextBox> textBoxes = TextBoxPanelFursh.Children.OfType<TextBox>().ToList();

                        List<CheckBox> checkBoxes = checkBoxPanelFursh.Children.OfType<CheckBox>().Where(cb => cb.IsChecked == true).ToList();
                        for (int i = 0; i < checkBoxes.Count; i++)
                        {
                            var selectedFurshId = (int)checkBoxes[i].Tag;
                            var count = textBoxes[i].Text;

                            var holidayfursh = new Holidayfursh
                            {
                                Holidayid = lastHolidayId,
                                Furshid = selectedFurshId,
                                Count = count
                            };

                            context.Holidayfursh.Add(holidayfursh);
                            context.SaveChanges();
                        }


                    }

                    using (var context = new calculatorContext())
                    {
                        foreach (var checkBox in checkBoxPanel.Children.OfType<CheckBox>().Where(cb => cb.IsChecked == true))
                        {
                            int servicesId = (int)checkBox.Tag; // Получаем Id сервиса из Tag чекбокса
                           

                            var holidayService = new Holidayservices // Создаем экземпляр Holidayservices и заполняем его данными
                            {
                                Holidayid = lastHolidayId, // Записываем последний добавленный праздник
                                Servicesid = servicesId
                            };


                            context.Holidayservices.Add(holidayService); // Добавляем данные в таблицу Holidayservices
                            context.SaveChanges(); // Сохраняем изменения в базе данных
                        }



                    }



                }
                else
                {

                    MessageBox.Show("Дата завершения мероприятия не может быть раньше, чем его начало");
                }
                
            }
            else
            {
                MessageBox.Show("Заполните фио, номер телефона и почту");
            }
            

        }

        private void TextBox_Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        private void TextBox_Time_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) <= 0;
        }

        private void TextBlock_Name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char l = e.Text[0];
            if ((l < 'A' || l < 'z') && l != '\b' && l != '.' && l != ' ')
            {
                e.Handled = true;
            }
        }

        private void TextBox_Date1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void TextBox_Date2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void TextBox_Mail_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            {
                char l = e.Text[0];
                if (!((l >= 'A' && l <= 'Z') || (l >= 'a' && l <= 'z') || l == '\b' || l == '.' || l == ' ' || l == '@' || (l >= '0' && l <= '9')))
                {
                    e.Handled = true;
                }
            }
        }
    }
}

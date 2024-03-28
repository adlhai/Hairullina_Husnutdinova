using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using calculate.Pages;

namespace calculate.Classes
{
    class Class_ConstantData
    {
        public static Windows.Calculate Calcul;
        public static string ID;
        public static MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;user=root;pwd=adelina2601;database=calculator");
    }
}
